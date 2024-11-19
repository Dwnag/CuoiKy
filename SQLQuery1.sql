CREATE DATABASE ql1;
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
CREATE TABLE Vat_lieu
(
  ma_vat_lieu VARCHAR(5) NOT NULL,
  ten_vat_lieu VARCHAR(25) NOT NULL,
  So_luong INT NOT NULL,
  Ghi_chu VARCHAR(50) NOT NULL,
  Loai VARCHAR(50) NOT NULL,
  PRIMARY KEY (ma_vat_lieu)
);

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
