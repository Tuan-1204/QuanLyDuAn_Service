BÁO CÁO DỰ ÁN: HỆ THỐNG QUẢN LÝ NHÂN VIÊN DỰ ÁN
1. Giới thiệu dự án
Hệ thống được xây dựng nhằm quản lý việc phân công nhân viên vào các dự án của công ty, theo dõi số giờ công và kết xuất báo cáo nghiệp vụ. Dự án áp dụng kiến trúc phần mềm hiện đại để đảm bảo tính mở rộng và bảo mật dữ liệu.

Công nghệ sử dụng: C# WinForms, WCF Service, SQL Server.

Kiến trúc: Mô hình 3 lớp (3-Tier Architecture) kết hợp Service-Oriented Architecture (SOA).

Công cụ báo cáo: Microsoft Reporting Services (RDLC).

2. Kiến trúc hệ thống
Dự án được chia thành các thành phần (Projects) riêng biệt để đảm bảo tính độc lập và dễ bảo trì:

MyApp.DTO (Data Transfer Object): Định nghĩa các lớp đối tượng như NhanvienDto, DuanDto, NhanvienDuanDto để truyền tải dữ liệu giữa các tầng.

MyApp.DAL (Data Access Layer): Thực hiện các truy vấn SQL trực tiếp (CRUD) và xử lý kết nối cơ sở dữ liệu.

MyApp.BUS (Business Logic Layer): Chứa các quy tắc nghiệp vụ, thực hiện bắt lỗi dữ liệu (ví dụ: không để trống mã, số giờ công phải dương) trước khi gửi xuống tầng DAL.

MyApp.WcfService: Đóng vai trò là tầng trung gian (Middleware), cung cấp các phương thức dịch vụ cho Client thông qua giao thức WCF.

GUI (Presentation Layer): Giao diện người dùng WinForms sử dụng mô hình MDI để quản lý các form con.

3. Các chức năng chính
Hệ thống thực hiện đầy đủ các yêu cầu nghiệp vụ:

3.1. Quản lý danh mục
Nhân viên: Quản lý thông tin hồ sơ nhân viên (Thêm, Sửa, Xóa).

Dự án: Quản lý danh sách các dự án đang triển khai và địa điểm thực hiện.

3.2. Nghiệp vụ phân công 
Thực hiện phân công nhân viên vào từng dự án cụ thể.

Theo dõi và cập nhật số giờ công của nhân viên.

Ràng buộc nghiệp vụ: Hệ thống tự động bắt lỗi và thông báo nếu dữ liệu nhập vào không hợp lệ (như thiếu mã hoặc số giờ công không hợp lệ) từ tầng BUS.

3.3. Báo cáo thống kê
Sử dụng RDLC để kết xuất báo cáo chuyên nghiệp.

Điều kiện lọc: Danh sách nhân viên tham gia dự án tại Hà Nội và có số giờ công > 10.

Thông tin bổ sung: Báo cáo tự động hiển thị Địa điểm in, Ngày/Tháng/Năm và Giờ in thực tế của hệ thống.

4. Hướng dẫn cài đặt và sử dụng
4.1. Chuẩn bị môi trường
Visual Studio 2019/2022.

SQL Server (chạy file script đính kèm để tạo Database).

Extension: Microsoft RDLC Report Designer.

4.2. Cấu hình
Mở Solution (.sln) và cấu hình lại chuỗi kết nối (Connection String) trong tầng DAL phù hợp với máy cá nhân.

Chạy dự án MyApp.WcfService trước để kích hoạt dịch vụ.

Chuột phải vào Service Reference trong Project GUI và chọn Update Service Reference.

5. Kết quả đạt được
Hệ thống chạy ổn định, không gặp lỗi MdiParent do đã cấu hình IsMdiContainer = True cho Form chính.

Dữ liệu báo cáo hiển thị đầy đủ, bao gồm cả "Tên dự án" nhờ kỹ thuật INNER JOIN trong câu lệnh SQL tại tầng DAL.

Dự án được quản lý phiên bản qua Git, đã cấu hình file .gitignore để loại bỏ các thư mục rác như .vs, bin, obj.

6.Database_QLDA.sql
-- 1. Tạo Database
CREATE DATABASE QuanLyDuAn;
GO
USE QuanLyDuAn;
GO

-- 2. Tạo bảng Nhân viên
CREATE TABLE Nhanvien (
    Manhanvien NVARCHAR(20) PRIMARY KEY,
    Hoten NVARCHAR(100) NOT NULL,
    Gioitinh NVARCHAR(10),
    Ngaysinh DATETIME
);
GO

-- 3. Tạo bảng Dự án
CREATE TABLE Duan (
    Mada NVARCHAR(20) PRIMARY KEY,
    Tenda NVARCHAR(200) NOT NULL,
    Diadiem NVARCHAR(200)
);
GO

-- 4. Tạo bảng trung gian Nhân viên - Dự án (Phân công)
CREATE TABLE NhanvienDuan (
    Manv NVARCHAR(20),
    Mada NVARCHAR(20),
    Sogiocong INT,
    CONSTRAINT PK_NhanvienDuan PRIMARY KEY (Manv, Mada),
    CONSTRAINT FK_NV FOREIGN KEY (Manv) REFERENCES Nhanvien(Manhanvien),
    CONSTRAINT FK_DA FOREIGN KEY (Mada) REFERENCES Duan(Mada)
);
GO

-- 5. Chèn dữ liệu mẫu để Test Báo cáo (Câu 2)
-- Nhân viên tham gia dự án tại Hà Nội và công > 10
INSERT INTO Nhanvien VALUES ('NV01', N'Nguyễn Anh Tuấn', N'Nam', '1995-10-15');
INSERT INTO Nhanvien VALUES ('NV02', N'Trần Thị Mai', N'Nữ', '1998-05-20');

INSERT INTO Duan VALUES ('DA01', N'Xây dựng phần mềm quản lý', N'Nguyễn Trãi, Hà Nội');
INSERT INTO Duan VALUES ('DA02', N'Lắp đặt hệ thống mạng', N'Quận 1, TP.HCM');

INSERT INTO NhanvienDuan VALUES ('NV01', 'DA01', 48); -- Thỏa mãn điều kiện báo cáo
INSERT INTO NhanvienDuan VALUES ('NV02', 'DA02', 15); -- Không thỏa mãn (Địa điểm)
GO

