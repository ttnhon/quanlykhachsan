--Insert <PhanQuyen>
use quanlykhachsan
go

alter table LoaiPhong add ConSuDung bit;
alter table DichVu add ConSuDung bit;

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
insert into KhachHang(TenKhach,SoCMND,DiaChi,DienThoai,LoaiKhach)
values  (N'Trần Văn Tài','0123456789',N'Hà Nội','0906758412','1'),
		(N'Nguyễn Thị Mơ','0365874165',N'Tp HCM','0122486531','1'),
		(N'John Wick','0356916327',N'Hải Phòng','0909555142','2'),
		(N'Huỳnh Nguyễn Hoài Lâm','0856975423',N'Vũng Tàu','0188645314','1')
--Insert <Phong>
insert into Phong(LoaiPhong,TinhTrang,TrangThai,GhiChu)
values	('1','1','3',N'Không có'),
		('2','1','3',N'Không có'),
		('3','2','1',N'Không có'),
		('4','3','4',N'Không có'),
		('5','2','2',N'Không có'),
		('1','1','3',N'Không có'),
		('2','1','3',N'Không có'),
		('3','2','1',N'Không có'),
		('4','3','4',N'Không có'),
		('1','2','2',N'Không có')
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
insert into LoaiPhong(MaLoai, TenLoai, MoTa, DonGia, SoNguoiToiDa, ConSuDung)
values  ('STD A', N'Standard A', N'2 giường đơn / 1 giường đôi', 680000, 2, 1),
		('STD B', N'Standard B', N'3 giường đơn / 1 giường đôi + 1 giường đơn', 850000, 3, 1),
		('STD C', N'Standard C', N'4 giường đơn / 2 giường đôi', 910000, 4, 1),
		('SUP A', N'Superior A', N'Chất lượng cao hơn Standard, 2 giường đơn/1 giường đôi', 890000, 2, 1),
		('SUP B', N'Superior B', N'Chất lượng cao hơn Standard, 3 giường đơn / 1 giường đôi + 1 giường đơn', 910000, 3, 1),
		('SUP C', N'Superior C', N'Chất lượng cao hơn Standard, 2 giường đơn + 1 giường đôi', 1100000, 4, 1),
		('DLX', N'Deluxe',N'Chất lượng cao hơn Superior, 2 giường đơn / 1 giường đôi', 1100000, 2, 1),
		('SUT A', N'Suite A',N'Chất lượng cao hơn Deluxe, 1 phòng ngủ + 1 phòng khách', 1500000, 2, 1),
		('SUT B', N'Suite B',N'Chất lượng cao hơn Deluxe, 2 phòng ngủ + 1 phòng khách', 1700000, 4, 1)

--Insert <DichVu>
insert into DichVu(TenDV, DonGia, GhiChu, ConSuDung)
values	(N'Thức ăn',100000,N'Có nhiều món để chọn lựa', 1),
		(N'Điểm tâm sáng',100000,N'Có nhiều món để chọn lựa', 1),
		(N'Thức ăn nhẹ',50000,N'Có nhiều món để chọn lựa', 1),
		(N'Thức uống',50000,N'Có nhiều loại thức uống để chọn lựa', 1),
		(N'Massage',200000,N'Không', 1),
		(N'BCS',25000,N'Ưu tiên phòng cặp đôi', 1)
--Insert <DatPhong>
--Insert <ChiTietDichVu>
--Insert <ThuePhong>
--Insert <HoaDon>

--Insert <BangThamSo>
insert into BangThamSo(TenTS, KieuDuLieu, GiaTri, ConHieuLuc)
values (N'Tỉ lệ phụ thu khách nước ngoài', 'float', '1.5', 1)
go