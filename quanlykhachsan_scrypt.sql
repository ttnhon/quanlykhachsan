create database quanlykhachsan;
go
use quanlykhachsan;
go
CREATE TABLE NguoiDung (
	MaSo INT NOT NULL IDENTITY(1,1),
	HoTen varchar(50) NOT NULL,
	LoaiNguoiDung varchar(30) NOT NULL,
	TenDangNhap varchar(30) NOT NULL,
	MatKhau varchar(30) NOT NULL,
	PRIMARY KEY (MaSo)
);
go
CREATE TABLE PhanQuyen (
	LoaiNguoiDung varchar(30) NOT NULL,
	MucDo INT NOT NULL,
	PRIMARY KEY (LoaiNguoiDung)
);
go
CREATE TABLE KhachHang (
	MaKhach INT NOT NULL IDENTITY(1,1),
	TenKhach varchar(30) NOT NULL,
	SoCMND varchar(20) NOT NULL,
	DiaChi varchar(50) NOT NULL,
	DienThoai varchar(20) NOT NULL,
	LoaiKhach INT NOT NULL,
	PRIMARY KEY (MaKhach)
);
go
CREATE TABLE Phong (
	MaPhong INT NOT NULL IDENTITY(1,1),
	LoaiPhong varchar(10) NOT NULL,
	TinhTrang INT NOT NULL,
	TrangThai INT NOT NULL,
	GhiChu varchar(50) NOT NULL,
	PRIMARY KEY (MaPhong)
);
go
CREATE TABLE LoaiKhach (
	MaLoai INT NOT NULL IDENTITY(1,1),
	LoaiKhach varchar(20) NOT NULL,
	PRIMARY KEY (MaLoai)
);
go
CREATE TABLE TinhTrangPhong (
	MaTT INT NOT NULL IDENTITY(1,1),
	TinhTrang varchar(20) NOT NULL,
	PRIMARY KEY (MaTT)
);
go
CREATE TABLE TrangThaiPhong (
	MaTT INT NOT NULL IDENTITY(1,1),
	TrangThai varchar(20) NOT NULL,
	PRIMARY KEY (MaTT)
);
go
CREATE TABLE LoaiPhong (
	MaLoai varchar(10) NOT NULL,
	TenLoai varchar(20) NOT NULL,
	MoTa varchar(50) NOT NULL,
	DonGia FLOAT NOT NULL,
	SoNguoiToiDa INT NOT NULL,
	PRIMARY KEY (MaLoai)
);
go
CREATE TABLE DichVu (
	MaDV INT NOT NULL IDENTITY(1,1),
	TenDV varchar(20) NOT NULL,
	DonGia FLOAT NOT NULL,
	GhiChu varchar(50) NOT NULL,
	PRIMARY KEY (MaDV)
);
go
CREATE TABLE DatPhong (
	MaPhong INT NOT NULL,
	MaKhach INT NOT NULL,
	NgayThue DATETIME NOT NULL,
	PRIMARY KEY (MaPhong,MaKhach,NgayThue)
);
go
CREATE TABLE ChiTietDichVu (
	MaDV INT NOT NULL,
	MaKhach INT NOT NULL,
	NgaySuDung DATETIME NOT NULL,
	SoLuong INT NOT NULL,
	MaPhong INT NOT NULL,
	PRIMARY KEY (MaDV,MaKhach,NgaySuDung)
);
go
CREATE TABLE ThuePhong (
	MaPhong INT NOT NULL,
	MaKhach INT NOT NULL,
	NgayBatDauThue DATETIME NOT NULL,
	SoNgayThue INT NOT NULL,
	PRIMARY KEY (MaPhong,MaKhach,NgayBatDauThue)
);
go
CREATE TABLE HoaDon (
	MaHD INT NOT NULL IDENTITY(1,1),
	MaKhach INT NOT NULL,
	MaPhong INT NOT NULL,
	NgayLap DATETIME NOT NULL,
	NgayBatDauThue DATETIME NOT NULL,
	NgayTraPhong DATETIME NOT NULL,
	ThanhTien FLOAT NOT NULL,
	PRIMARY KEY (MaHD)
);
go
CREATE TABLE BangThamSo (
	MaTS INT NOT NULL IDENTITY(1,1),
	TenTS varchar(30) NOT NULL,
	KieuDuLieu varchar(15) NOT NULL,
	GiaTri varchar(15) NOT NULL,
	ConHieuLuc bit NOT NULL,
	PRIMARY KEY (MaTS)
);
go
ALTER TABLE NguoiDung ADD CONSTRAINT NguoiDung_fk0 FOREIGN KEY (LoaiNguoiDung) REFERENCES PhanQuyen(LoaiNguoiDung);
go
ALTER TABLE KhachHang ADD CONSTRAINT KhachHang_fk0 FOREIGN KEY (LoaiKhach) REFERENCES LoaiKhach(MaLoai);
go
ALTER TABLE Phong ADD CONSTRAINT Phong_fk0 FOREIGN KEY (LoaiPhong) REFERENCES LoaiPhong(MaLoai);
go
ALTER TABLE Phong ADD CONSTRAINT Phong_fk1 FOREIGN KEY (TinhTrang) REFERENCES TinhTrangPhong(MaTT);
go
ALTER TABLE Phong ADD CONSTRAINT Phong_fk2 FOREIGN KEY (TrangThai) REFERENCES TrangThaiPhong(MaTT);
go
ALTER TABLE DatPhong ADD CONSTRAINT DatPhong_fk0 FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
go
ALTER TABLE DatPhong ADD CONSTRAINT DatPhong_fk1 FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach);
go
ALTER TABLE ChiTietDichVu ADD CONSTRAINT ChiTietDichVu_fk0 FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV);
go
ALTER TABLE ChiTietDichVu ADD CONSTRAINT ChiTietDichVu_fk1 FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach);
go
ALTER TABLE ChiTietDichVu ADD CONSTRAINT ChiTietDichVu_fk2 FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
go
ALTER TABLE ThuePhong ADD CONSTRAINT ThuePhong_fk0 FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
go
ALTER TABLE ThuePhong ADD CONSTRAINT ThuePhong_fk1 FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach);
go
ALTER TABLE HoaDon ADD CONSTRAINT HoaDon_fk0 FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach);
go
ALTER TABLE HoaDon ADD CONSTRAINT HoaDon_fk1 FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
go