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
values  ('STD A', N'Standard A', N'2 giường đơn / 1 giường đôi', 680000, 2),
		('STD B', N'Standard B', N'3 giường đơn / 1 giường đôi + 1 giường đơn', 850000, 3),
		('STD C', N'Standard C', N'4 giường đơn / 2 giường đôi', 910000, 4),
		('SUP A', N'Superior A', N'Chất lượng cao hơn Standard, 2 giường đơn/1 giường đôi', 890000, 2),
		('SUP B', N'Superior B', N'Chất lượng cao hơn Standard, 3 giường đơn / 1 giường đôi + 1 giường đơn', 910000, 3),
		('SUP C', N'Superior C', N'Chất lượng cao hơn Standard, 2 giường đơn + 1 giường đôi', 1100000, 4),
		('DLX', N'Deluxe',N'Chất lượng cao hơn Superior, 2 giường đơn / 1 giường đôi', 1100000, 2),
		('SUT A', N'Suite A',N'Chất lượng cao hơn Deluxe, 1 phòng ngủ + 1 phòng khách', 1500000, 2),
		('SUT B', N'Suite B',N'Chất lượng cao hơn Deluxe, 2 phòng ngủ + 1 phòng khách', 1700000, 4)

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