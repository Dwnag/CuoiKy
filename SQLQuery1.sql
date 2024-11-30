﻿CREATE DATABASE ql1;
GO

-- Tao bang Benh nhan
CREATE TABLE Benh_nhan
(
  Ma_benh_nhan VARCHAR(5) NOT NULL,
  Ngay_sinh DATE NOT NULL,
  Ten VARCHAR(25) NOT NULL,
  PRIMARY KEY (Ma_benh_nhan)
);

-- Tao bang Vat lieu


CREATE TABLE Benh_an
(
  ma_benh_an VARCHAR(5) NOT NULL,
  Ma_benh_nhan VARCHAR(5) NOT NULL,
  PRIMARY KEY (ma_benh_an),
  FOREIGN KEY (Ma_benh_nhan) REFERENCES Benh_nhan(Ma_benh_nhan)
);

-- Tao bang Bac si
CREATE TABLE Bac_si
(
  Ma_bac_si VARCHAR(5) NOT NULL,
  Ten VARCHAR(25) NOT NULL,
  PRIMARY KEY (Ma_bac_si)
);

-- Tao bang Le tan
CREATE TABLE Le_tan
(
  Ma_le_tan VARCHAR(5) NOT NULL,
  Ten_le_tan VARCHAR(25) NOT NULL,
  Ma_bac_si VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_le_tan),
  FOREIGN KEY (Ma_bac_si) REFERENCES Bac_si(Ma_bac_si)
);

-- Tao bang Kiem kho
CREATE TABLE Kiem_kho
(
  Ma_kho VARCHAR(5) NOT NULL,
  Ten_kho VARCHAR(25) NOT NULL,
  PRIMARY KEY (Ma_kho)
);




-- Tao bang Kho
CREATE TABLE Kho
(
  So_luong INT NOT NULL,
  Don_gia FLOAT NOT NULL,
  Ma_hang VARCHAR(5) NOT NULL,
  Ma_kho VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_hang),
  FOREIGN KEY (Ma_kho) REFERENCES Kiem_kho(Ma_kho)
);

-- Tao bang Thuoc
CREATE TABLE Thuoc
(
  Gia_ban FLOAT NOT NULL,
  Ham_luong FLOAT NOT NULL,
  ma_vat_lieu VARCHAR(5) NOT NULL,
  PRIMARY KEY (ma_vat_lieu),
  FOREIGN KEY (ma_vat_lieu) REFERENCES Vat_lieu(ma_vat_lieu)
);
drop table Thuoc
-- Tao bang Hoa don
CREATE TABLE Hoa_don
(
  Ma_hoa_don VARCHAR(5) NOT NULL,
  Ngay_xuat_hoa_don DATE NOT NULL,
  Tong_tien FLOAT NOT NULL,
  PRIMARY KEY (Ma_hoa_don)
);

-- Tao bang Su dung
CREATE TABLE Su_dung
(
  Ma_benh_nhan VARCHAR(5) NOT NULL,
  ma_vat_lieu VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_benh_nhan, ma_vat_lieu),
  FOREIGN KEY (Ma_benh_nhan) REFERENCES Benh_nhan(Ma_benh_nhan),
  FOREIGN KEY (ma_vat_lieu) REFERENCES Vat_lieu(ma_vat_lieu)
);
drop table Su_dung
-- Tao bang Kham benh
CREATE TABLE Kham_benh
(
  Ma_benh_nhan VARCHAR(5) NOT NULL,
  Ma_bac_si VARCHAR(5) NOT NULL,
  PRIMARY KEY (Ma_benh_nhan, Ma_bac_si),
  FOREIGN KEY (Ma_benh_nhan) REFERENCES Benh_nhan(Ma_benh_nhan),
  FOREIGN KEY (Ma_bac_si) REFERENCES Bac_si(Ma_bac_si)
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

-- Tao ham de tao ma benh nhan
CREATE FUNCTION dbo.fn_TaoMaBenhNhan
(
    @Prefix NVARCHAR(5)  -- Tiền tố của mã, ví dụ 'BN'
)
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @MaxCode NVARCHAR(10);
    DECLARE @NextNumber INT;
    DECLARE @NewCode NVARCHAR(10);
    
    -- Lấy mã lớn nhất hiện có từ bảng Benh_nhan
    SELECT @MaxCode = MAX(Ma_benh_nhan)
    FROM Benh_nhan
    WHERE Ma_benh_nhan LIKE @Prefix + '%'; -- Chỉ lấy mã có cùng tiền tố
    
    -- Nếu chưa có mã nào, bắt đầu từ 1
    IF @MaxCode IS NULL
    BEGIN
        SET @NextNumber = 1;
    END
    ELSE
    BEGIN
        -- Tách phần số từ mã hiện có và tăng thêm 1
        SET @NextNumber = 
            TRY_CAST(SUBSTRING(@MaxCode, LEN(@Prefix) + 1, LEN(@MaxCode) - LEN(@Prefix)) AS INT) + 1;

        -- Nếu phần số không thể tách (do dữ liệu sai), mặc định là 1
        IF @NextNumber IS NULL
        BEGIN
            SET @NextNumber = 1;
        END
    END

    -- Tạo mã mới với định dạng Prefix + số thứ tự
    SET @NewCode = @Prefix + RIGHT('000' + CAST(@NextNumber AS NVARCHAR(10)), 3);
    
    RETURN @NewCode;
END;
GO

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
