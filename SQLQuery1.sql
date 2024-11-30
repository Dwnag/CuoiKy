CREATE DATABASE ql1;
GO

-- Tao bang Bac si
CREATE TABLE Bac_si
(
  Ma_bac_si VARCHAR(5) NOT NULL,
  Ten VARCHAR(25) NOT NULL,
  PRIMARY KEY (Ma_bac_si)
);

-- Tao bang Benh nhan
CREATE TABLE BenhNhan(
	ID INT IDENTITY PRIMARY KEY,
    Ho NVARCHAR(50),
    Ten NVARCHAR(50),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SDT NVARCHAR(15),
    DiaChi NVARCHAR(255),
    Gmail NVARCHAR(100),
    MaKham NVARCHAR(50),
    ChuanDoan NVARCHAR(255),
	phong nvarchar(8),
	Khoa nvarchar(50)
);


-- Tao bang Nhap thong tin
CREATE TABLE Nhap_thong_tin
(
  Ma_thong_tin VARCHAR(5) NOT NULL,
  Ten_thong_tin VARCHAR(25) NOT NULL,
  Ma_benh_nhan VARCHAR(5) NOT NULL,
  Ma_le_tan VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_thong_tin),
  FOREIGN KEY (Ma_benh_nhan) REFERENCES Benh_nhan(Ma_benh_nhan),
  FOREIGN KEY (Ma_le_tan) REFERENCES Le_tan(Ma_le_tan),
  UNIQUE (Ma_benh_nhan, Ma_le_tan)
);

-- Tao bang Lich lam viec
CREATE TABLE Lich_lam_viec
(
  Ma_lich_lam VARCHAR(5) NOT NULL,
  Ten_lich_lam VARCHAR(25) NOT NULL,
  Ma_le_tan VARCHAR(5) NOT NULL,
  Ma_kho VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_lich_lam),
  FOREIGN KEY (Ma_le_tan) REFERENCES Le_tan(Ma_le_tan),
  FOREIGN KEY (Ma_kho) REFERENCES Kiem_kho(Ma_kho),
  UNIQUE (Ma_le_tan, Ma_kho)
);

-- Tao bang Thanh toan
CREATE TABLE Thanh_toan
(
  Ma_le_tan VARCHAR(5) NOT NULL,
  Ma_hoa_don VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_le_tan, Ma_hoa_don),
  FOREIGN KEY (Ma_le_tan) REFERENCES Le_tan(Ma_le_tan),
  FOREIGN KEY (Ma_hoa_don) REFERENCES Hoa_don(Ma_hoa_don)
);


CREATE TABLE TaiKhoan
(
    TenTaiKhoan VARCHAR(50) NOT NULL PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    LoaiTaiKhoan VARCHAR(20) NOT NULL
);

INSERT INTO TaiKhoan (TenTaiKhoan, MatKhau, LoaiTaiKhoan) VALUES 
('a1', 'a1', 'letan'),
('a2', 'a2', 'bacsi'),
('a3', 'a3', 'quanlykho'),
('a4', 'a4', 'chuphongkham');

-- Bang cho Vat lieu
CREATE TABLE VatLieu (
    MaVatLieu NVARCHAR(50) PRIMARY KEY,
    TenVatLieu NVARCHAR(50) NOT NULL,
    MauSac NVARCHAR(20),
    KichCo NVARCHAR(20),
    DVT NVARCHAR(20),              -- Don vi tinh
    TriGia DECIMAL(18, 2),         -- Gia tri
    SoLuong INT,                   -- So luong
    GhiChu NVARCHAR(255),          -- Ghi chu
    LoaiVatLieu NVARCHAR(50),      -- Loai (Vat lieu co dinh, Vat lieu tieu hao)
    HanSuDung DATE                 -- Han su dung
);

-- Bang cho Thuoc
CREATE TABLE Thuoc (
    MaThuoc NVARCHAR(50) PRIMARY KEY,
    TenThuoc NVARCHAR(50) NOT NULL,    -- Ten thuoc
    DVT NVARCHAR(20),                  -- Don vi tinh
    SoLuong INT,                       -- So luong
    GiaBan DECIMAL(18, 2),             -- Gia ban
    HamLuong NVARCHAR(50),             -- Ham luong
    GhiChu NVARCHAR(255),              -- Ghi chu
    LoaiThuoc NVARCHAR(50),            -- Loai thuoc (Khang viem, Khang sinh, Giam dau)
    HanSuDung DATE                     -- Han su dung
);

GO
CREATE FUNCTION GenerateMaVatLieu()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @MaVatLieu VARCHAR(10);
    
    -- Find the latest MaVatLieu
    SELECT TOP 1 @MaVatLieu = MaVatLieu
    FROM VatLieu
    WHERE MaVatLieu LIKE 'VL%'
    ORDER BY MaVatLieu DESC;
    
    -- If there's no existing MaVatLieu, start with 'VL0001'
    IF @MaVatLieu IS NULL
        SET @MaVatLieu = 'VL0001';
    ELSE
        -- Increment the numeric part of the code
        SET @MaVatLieu = 'VL' + RIGHT('0000' + CAST(CAST(SUBSTRING(@MaVatLieu, 3, LEN(@MaVatLieu) - 2) AS INT) + 1 AS VARCHAR), 4);

    RETURN @MaVatLieu;
END;
GO

CREATE FUNCTION GenerateMaThuoc()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @MaThuoc CHAR(8);

    -- Generate the new MaThuoc code with prefix 'T' and padded number
    SELECT @MaThuoc = 'T' + RIGHT('0000' + 
        CAST(ISNULL(MAX(CAST(SUBSTRING(CAST(MaThuoc AS VARCHAR), 2, LEN(MaThuoc) - 1) AS INT)), 0) + 1 AS VARCHAR), 7)
    FROM Thuoc;

    RETURN @MaThuoc;
END;
GO

INSERT INTO VatLieu (MaVatLieu, TenVatLieu, MauSac, KichCo, DVT, TriGia, SoLuong, GhiChu, LoaiVatLieu, HanSuDung)
VALUES (dbo.GenerateMaVatLieu(), N'Mũi Cạo vôi', NULL, NULL, N'Cái', 15000.00, 100, NULL, N'Vật liệu cố định', '2024-12-31');

INSERT INTO Thuoc (MaThuoc, TenThuoc, DVT, SoLuong, GiaBan, HamLuong, GhiChu, LoaiThuoc, HanSuDung)
VALUES (dbo.GenerateMaThuoc(), N'Amoxicillin', N'Lọ', 30, 100000.00, '500mg', NULL, N'Kháng sinh', '2026-12-15');

SELECT * FROM VatLieu;

CREATE TABLE Appointments (
    ID INT IDENTITY PRIMARY KEY,
    Ho NVARCHAR(50),
    Ten NVARCHAR(50),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SDT NVARCHAR(15),
    DiaChi NVARCHAR(255),
    Gmail NVARCHAR(100),
    MaKham NVARCHAR(50),
    ChuanDoan NVARCHAR(255),
    NgayHen Nvarchar(50),
    DichVu NVARCHAR(100),
    KhungGio NVARCHAR(50),
    BacSi NVARCHAR(100)
);
