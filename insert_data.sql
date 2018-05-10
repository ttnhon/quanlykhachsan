--Insert <PhanQuyen>
use quanlykhachsan
go

insert into PhanQuyen(LoaiNguoiDung, MucDo)
values	(N'Giám đốc', 1),
		(N'Quản lý', 2),
		(N'Nhân viên', 3)
go
--Insert <NguoiDung>
insert into NguoiDung(HoTen, LoaiNguoiDung, TenDangNhap, MatKhau)
values	(N'Trương Thành Nhơn', N'Giám đốc', 'ttnhon', '1'),
		(N'Huỳnh Phi Phúc', N'Quản lý', 'hpphuc', '1'),
		(N'Nguyễn Văn Phúc', N'Nhân viên', 'nvphuc', '1')
go
--Insert <KhachHang>
--Insert <Phong>
--Insert <LoaiKhach>
insert into LoaiKhach(LoaiKhach)
values (N'Nội địa'), (N'Nước ngoài')
go
--Insert <TinhTrangPhong>
insert into TinhTrangPhong(TinhTrang)
values (N'Còn trống'), (N'Đang thuê'), (N'Ngưng sử dụng')
go
--Insert <TrangThaiPhong>
insert into TrangThaiPhong(TrangThai)
values (N'Khách trong phòng'), (N'Khách ra ngoài'), (N'Đang dọn dẹp'), (N'Đang sửa chữa')
go
--Insert <LoaiPhong>
insert into LoaiPhong(MaLoai, TenLoai, MoTa, DonGia, SoNguoiToiDa)
values  ('1',N'thường',N'Loại phòng phổ thông',500000,3),
		('2',N'chuẩn',N'Loại phòng trung lưu, tiện nghi khá',1000000,2),
		('3',N'tầm nhìn đẹp',N'Tầm nhìn đẹp và thoáng đãng',1200000,2),
		('4',N'cặp đôi',N'Dành cho cặp đôi',700000,2),
		('5',N'vip',N'Chuẩn cao cấp, tiện nghi sang trọng',1500000,2)

--Insert <DichVu>
insert into DichVu(TenDV, DonGia, GhiChu)
values	(N'Thức ăn',100000,N'Có nhiều món để chọn lựa'),
		(N'Điểm tâm sáng',100000,N'Có nhiều món để chọn lựa'),
		(N'Thức ăn nhẹ',50000,N'Có nhiều món để chọn lựa'),
		(N'Thức uống',50000,N'Có nhiều loại thức uống để chọn lựa'),
		(N'Massage',200000,N'Không'),
		(N'BCS',25000,N'Ưu tiên phòng cặp đôi')
--Insert <DatPhong>
--Insert <ChiTietDichVu>
--Insert <ThuePhong>
--Insert <HoaDon>

--Insert <BangThamSo>
insert into BangThamSo(TenTS, KieuDuLieu, GiaTri, ConHieuLuc)
values (N'Tỉ lệ phụ thu khách nước ngoài', 'float', '1.5', 1)
go