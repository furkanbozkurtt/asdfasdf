-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 10 May 2017, 12:33:20
-- Sunucu sürümü: 10.1.19-MariaDB
-- PHP Sürümü: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `magazaotomasyonu`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `beden`
--

CREATE TABLE `beden` (
  `BedenId` int(11) NOT NULL,
  `BedenAdi` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `beden`
--

INSERT INTO `beden` (`BedenId`, `BedenAdi`) VALUES
(2, '021'),
(3, '0211');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `degisim`
--

CREATE TABLE `degisim` (
  `DegisimId` int(11) NOT NULL,
  `DegisimAdedi` int(11) NOT NULL,
  `DegisimTarihi` date NOT NULL,
  `DegisimAciklama` varchar(50) NOT NULL,
  `UrunId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `departman`
--

CREATE TABLE `departman` (
  `DepartmanId` int(11) NOT NULL,
  `DepartmanAdi` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `departman`
--

INSERT INTO `departman` (`DepartmanId`, `DepartmanAdi`) VALUES
(1, 'Elbise'),
(2, 'etek'),
(3, '1231'),
(6, 'qweqw');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `desen`
--

CREATE TABLE `desen` (
  `DesenId` int(11) NOT NULL,
  `DesenAdi` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `desen`
--

INSERT INTO `desen` (`DesenId`, `DesenAdi`) VALUES
(2, '2'),
(3, '2');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `fatura`
--

CREATE TABLE `fatura` (
  `FaturaId` int(11) NOT NULL,
  `SatisId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `iade`
--

CREATE TABLE `iade` (
  `IadeID` int(11) NOT NULL,
  `IadeAdedi` int(12) NOT NULL,
  `IadeTarihi` date NOT NULL,
  `IadeAciklama` varchar(50) NOT NULL,
  `UrunId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategori`
--

CREATE TABLE `kategori` (
  `KategoriId` int(11) NOT NULL,
  `KategoriAdId` int(11) NOT NULL,
  `BedenId` int(11) NOT NULL,
  `MarkaId` int(11) NOT NULL,
  `DesenId` int(11) NOT NULL,
  `RenkId` int(11) NOT NULL,
  `TipId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kategori`
--

INSERT INTO `kategori` (`KategoriId`, `KategoriAdId`, `BedenId`, `MarkaId`, `DesenId`, `RenkId`, `TipId`) VALUES
(5, 1, 2, 2, 2, 1, 1),
(6, 1, 2, 2, 2, 1, 1),
(7, 1, 2, 2, 2, 1, 1),
(8, 1, 2, 2, 2, 1, 1),
(9, 1, 2, 2, 2, 1, 1),
(10, 1, 2, 2, 2, 1, 1),
(11, 1, 2, 2, 2, 1, 1),
(12, 1, 2, 2, 2, 1, 1),
(13, 1, 2, 2, 2, 1, 1),
(14, 1, 2, 2, 2, 1, 1),
(15, 1, 2, 2, 2, 1, 1),
(16, 1, 2, 2, 2, 1, 1),
(17, 1, 2, 2, 2, 1, 1),
(18, 1, 2, 2, 2, 1, 1),
(19, 1, 2, 2, 2, 1, 1),
(20, 1, 2, 2, 2, 1, 1),
(21, 1, 2, 2, 2, 1, 1),
(22, 1, 2, 2, 2, 1, 1),
(23, 1, 2, 2, 2, 1, 1),
(24, 1, 2, 2, 2, 1, 1),
(25, 1, 2, 2, 2, 1, 1),
(26, 1, 2, 2, 2, 1, 1),
(27, 1, 2, 2, 2, 1, 1),
(28, 1, 2, 2, 2, 1, 1),
(29, 1, 2, 2, 2, 1, 1),
(30, 1, 2, 2, 2, 1, 1),
(31, 1, 2, 2, 2, 1, 1),
(32, 1, 2, 2, 2, 1, 1),
(33, 1, 2, 2, 2, 1, 1),
(34, 1, 2, 2, 2, 1, 1),
(35, 1, 2, 2, 2, 1, 1),
(36, 1, 2, 2, 2, 1, 1),
(37, 1, 2, 2, 2, 1, 1),
(38, 1, 2, 2, 2, 1, 1),
(39, 1, 2, 2, 2, 1, 1),
(40, 1, 2, 2, 2, 1, 1),
(41, 1, 2, 2, 2, 1, 1),
(42, 1, 2, 2, 2, 1, 1),
(43, 1, 2, 2, 2, 1, 1),
(44, 1, 2, 2, 2, 1, 1),
(45, 1, 2, 2, 2, 1, 1),
(46, 1, 2, 2, 2, 1, 1),
(47, 1, 2, 2, 2, 1, 1),
(48, 1, 2, 2, 2, 1, 1),
(49, 1, 2, 2, 2, 1, 1),
(50, 1, 2, 2, 2, 1, 1),
(51, 1, 2, 2, 2, 1, 1),
(52, 1, 2, 2, 2, 1, 1),
(53, 1, 2, 2, 2, 1, 1),
(54, 1, 2, 2, 2, 1, 1),
(55, 1, 2, 2, 2, 1, 1),
(56, 1, 2, 2, 2, 1, 1),
(57, 1, 2, 2, 2, 1, 1),
(58, 1, 2, 2, 2, 1, 1),
(59, 3, 3, 2, 2, 2, 2),
(60, 3, 3, 2, 2, 2, 2),
(61, 1, 2, 2, 2, 1, 1),
(62, 1, 2, 2, 2, 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategoriad`
--

CREATE TABLE `kategoriad` (
  `KategoriAdId` int(11) NOT NULL,
  `KategoriAdi` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kategoriad`
--

INSERT INTO `kategoriad` (`KategoriAdId`, `KategoriAdi`) VALUES
(1, '1'),
(2, '1'),
(3, '1'),
(5, '4');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `KullaniciId` int(11) NOT NULL,
  `KullaniciAdi` varchar(12) NOT NULL,
  `Sifre` int(12) NOT NULL,
  `Yetki` int(12) NOT NULL,
  `PersonelId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`KullaniciId`, `KullaniciAdi`, `Sifre`, `Yetki`, `PersonelId`) VALUES
(1, 'a', 1, 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `magaza`
--

CREATE TABLE `magaza` (
  `MagazaId` int(11) NOT NULL,
  `SubeAdi` varchar(12) NOT NULL,
  `MagazaTel` int(15) NOT NULL,
  `MagazaAdresi` text NOT NULL,
  `Sehir` varchar(15) NOT NULL,
  `DepartmanId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `magaza`
--

INSERT INTO `magaza` (`MagazaId`, `SubeAdi`, `MagazaTel`, `MagazaAdresi`, `Sehir`, `DepartmanId`) VALUES
(1, 'Sivas', 1234, 'hebeke', 'sivas', 2);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `marka`
--

CREATE TABLE `marka` (
  `MarkaId` int(11) NOT NULL,
  `MarkaAdi` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `marka`
--

INSERT INTO `marka` (`MarkaId`, `MarkaAdi`) VALUES
(2, '4124'),
(3, '412412');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `meslek`
--

CREATE TABLE `meslek` (
  `MeslekId` int(11) NOT NULL,
  `MeslekAdi` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `meslek`
--

INSERT INTO `meslek` (`MeslekId`, `MeslekAdi`) VALUES
(1, 'Satis'),
(2, 'kasiyer'),
(3, 'alici'),
(4, 'deneee'),
(5, 'denemee'),
(6, '123123'),
(7, '123'),
(8, 'zxczc'),
(9, 'qweqwe'),
(10, '123123'),
(11, '1'),
(12, 'z'),
(13, '123');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `personel`
--

CREATE TABLE `personel` (
  `PersonelId` int(11) NOT NULL,
  `PersonelAdi` varchar(15) NOT NULL,
  `PersonelSoyadi` varchar(15) NOT NULL,
  `PersonelTel` int(15) NOT NULL,
  `PersonelAdres` text NOT NULL,
  `GirisTarihi` date NOT NULL,
  `Maas` int(12) NOT NULL,
  `DepartmanId` int(11) NOT NULL,
  `MeslekId` int(11) NOT NULL,
  `MagazaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `personel`
--

INSERT INTO `personel` (`PersonelId`, `PersonelAdi`, `PersonelSoyadi`, `PersonelTel`, `PersonelAdres`, `GirisTarihi`, `Maas`, `DepartmanId`, `MeslekId`, `MagazaId`) VALUES
(1, 'erhan', 'bilgin', 123, 'qweqwe', '2017-05-01', 1231, 1, 3, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `renk`
--

CREATE TABLE `renk` (
  `RenkId` int(11) NOT NULL,
  `RenkKodu` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `renk`
--

INSERT INTO `renk` (`RenkId`, `RenkKodu`) VALUES
(1, 3),
(2, 33);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satis`
--

CREATE TABLE `satis` (
  `SatisId` int(11) NOT NULL,
  `SatisAdedi` int(11) NOT NULL,
  `SatisTarihi` date NOT NULL,
  `UrunId` int(11) NOT NULL,
  `MagazaId` int(11) NOT NULL,
  `PersonelId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stok`
--

CREATE TABLE `stok` (
  `StokId` int(11) NOT NULL,
  `StokAdedi` int(12) NOT NULL,
  `UrunId` int(11) NOT NULL,
  `MagazaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `stok`
--

INSERT INTO `stok` (`StokId`, `StokAdedi`, `UrunId`, `MagazaId`) VALUES
(1, 3123, 2, 1),
(2, 123, 3, 1),
(3, 123, 4, 1),
(4, 13, 5, 1),
(5, 132, 6, 1),
(6, 123, 6, 1),
(7, 4123, 9, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tip`
--

CREATE TABLE `tip` (
  `TipId` int(11) NOT NULL,
  `TipAdi` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `tip`
--

INSERT INTO `tip` (`TipId`, `TipAdi`) VALUES
(1, '123'),
(2, '1231412'),
(3, '1');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun`
--

CREATE TABLE `urun` (
  `UrunId` int(11) NOT NULL,
  `UrunAdi` varchar(20) NOT NULL,
  `UrunFiyati` int(12) NOT NULL,
  `KateoriId` int(11) NOT NULL,
  `Barkod` int(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `urun`
--

INSERT INTO `urun` (`UrunId`, `UrunAdi`, `UrunFiyati`, `KateoriId`, `Barkod`) VALUES
(1, '13213', 123, 44, 2),
(2, '123', 123, 46, 2),
(3, '231123123', 12312, 48, 2),
(4, '3123', 123123, 50, 2),
(5, '3123', 321, 52, 2),
(6, '231', 312, 54, 2),
(8, '123', 412, 58, 58),
(9, '123', 123, 60, 55);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `beden`
--
ALTER TABLE `beden`
  ADD PRIMARY KEY (`BedenId`);

--
-- Tablo için indeksler `degisim`
--
ALTER TABLE `degisim`
  ADD PRIMARY KEY (`DegisimId`),
  ADD KEY `UrunId` (`UrunId`);

--
-- Tablo için indeksler `departman`
--
ALTER TABLE `departman`
  ADD PRIMARY KEY (`DepartmanId`);

--
-- Tablo için indeksler `desen`
--
ALTER TABLE `desen`
  ADD PRIMARY KEY (`DesenId`);

--
-- Tablo için indeksler `fatura`
--
ALTER TABLE `fatura`
  ADD PRIMARY KEY (`FaturaId`),
  ADD KEY `SatisId` (`SatisId`);

--
-- Tablo için indeksler `iade`
--
ALTER TABLE `iade`
  ADD PRIMARY KEY (`IadeID`),
  ADD KEY `UrunId` (`UrunId`);

--
-- Tablo için indeksler `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`KategoriId`),
  ADD KEY `KategoriAdId` (`KategoriAdId`),
  ADD KEY `BedenId` (`BedenId`),
  ADD KEY `MarkaId` (`MarkaId`),
  ADD KEY `DesenId` (`DesenId`),
  ADD KEY `RenkId` (`RenkId`),
  ADD KEY `TipId` (`TipId`);

--
-- Tablo için indeksler `kategoriad`
--
ALTER TABLE `kategoriad`
  ADD PRIMARY KEY (`KategoriAdId`);

--
-- Tablo için indeksler `kullanici`
--
ALTER TABLE `kullanici`
  ADD PRIMARY KEY (`KullaniciId`),
  ADD KEY `PersonelId` (`PersonelId`);

--
-- Tablo için indeksler `magaza`
--
ALTER TABLE `magaza`
  ADD PRIMARY KEY (`MagazaId`),
  ADD KEY `DepartmanId` (`DepartmanId`);

--
-- Tablo için indeksler `marka`
--
ALTER TABLE `marka`
  ADD PRIMARY KEY (`MarkaId`);

--
-- Tablo için indeksler `meslek`
--
ALTER TABLE `meslek`
  ADD PRIMARY KEY (`MeslekId`);

--
-- Tablo için indeksler `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`PersonelId`),
  ADD KEY `DepartmanId` (`DepartmanId`),
  ADD KEY `MeslekId` (`MeslekId`),
  ADD KEY `MagazaId` (`MagazaId`);

--
-- Tablo için indeksler `renk`
--
ALTER TABLE `renk`
  ADD PRIMARY KEY (`RenkId`);

--
-- Tablo için indeksler `satis`
--
ALTER TABLE `satis`
  ADD PRIMARY KEY (`SatisId`),
  ADD KEY `UrunId` (`UrunId`),
  ADD KEY `MagazaId` (`MagazaId`),
  ADD KEY `PersonelId` (`PersonelId`);

--
-- Tablo için indeksler `stok`
--
ALTER TABLE `stok`
  ADD PRIMARY KEY (`StokId`),
  ADD KEY `UrunId` (`UrunId`),
  ADD KEY `MagazaId` (`MagazaId`);

--
-- Tablo için indeksler `tip`
--
ALTER TABLE `tip`
  ADD PRIMARY KEY (`TipId`);

--
-- Tablo için indeksler `urun`
--
ALTER TABLE `urun`
  ADD PRIMARY KEY (`UrunId`),
  ADD KEY `KateoriId` (`KateoriId`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `beden`
--
ALTER TABLE `beden`
  MODIFY `BedenId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- Tablo için AUTO_INCREMENT değeri `degisim`
--
ALTER TABLE `degisim`
  MODIFY `DegisimId` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `departman`
--
ALTER TABLE `departman`
  MODIFY `DepartmanId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Tablo için AUTO_INCREMENT değeri `desen`
--
ALTER TABLE `desen`
  MODIFY `DesenId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- Tablo için AUTO_INCREMENT değeri `fatura`
--
ALTER TABLE `fatura`
  MODIFY `FaturaId` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `iade`
--
ALTER TABLE `iade`
  MODIFY `IadeID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `kategori`
--
ALTER TABLE `kategori`
  MODIFY `KategoriId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;
--
-- Tablo için AUTO_INCREMENT değeri `kategoriad`
--
ALTER TABLE `kategoriad`
  MODIFY `KategoriAdId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `KullaniciId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Tablo için AUTO_INCREMENT değeri `magaza`
--
ALTER TABLE `magaza`
  MODIFY `MagazaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Tablo için AUTO_INCREMENT değeri `marka`
--
ALTER TABLE `marka`
  MODIFY `MarkaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- Tablo için AUTO_INCREMENT değeri `meslek`
--
ALTER TABLE `meslek`
  MODIFY `MeslekId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- Tablo için AUTO_INCREMENT değeri `personel`
--
ALTER TABLE `personel`
  MODIFY `PersonelId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Tablo için AUTO_INCREMENT değeri `renk`
--
ALTER TABLE `renk`
  MODIFY `RenkId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Tablo için AUTO_INCREMENT değeri `satis`
--
ALTER TABLE `satis`
  MODIFY `SatisId` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `stok`
--
ALTER TABLE `stok`
  MODIFY `StokId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- Tablo için AUTO_INCREMENT değeri `tip`
--
ALTER TABLE `tip`
  MODIFY `TipId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- Tablo için AUTO_INCREMENT değeri `urun`
--
ALTER TABLE `urun`
  MODIFY `UrunId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `degisim`
--
ALTER TABLE `degisim`
  ADD CONSTRAINT `FK_users_role_map1` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `degisim_ibfk_1` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`);

--
-- Tablo kısıtlamaları `fatura`
--
ALTER TABLE `fatura`
  ADD CONSTRAINT `FK_heebele` FOREIGN KEY (`SatisId`) REFERENCES `satis` (`SatisId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fatura_ibfk_1` FOREIGN KEY (`SatisId`) REFERENCES `satis` (`SatisId`);

--
-- Tablo kısıtlamaları `iade`
--
ALTER TABLE `iade`
  ADD CONSTRAINT `FK_heebele1` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `iade_ibfk_1` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`);

--
-- Tablo kısıtlamaları `kategori`
--
ALTER TABLE `kategori`
  ADD CONSTRAINT `FK_heebele2` FOREIGN KEY (`KategoriAdId`) REFERENCES `kategoriad` (`KategoriAdId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele3` FOREIGN KEY (`BedenId`) REFERENCES `beden` (`BedenId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele4` FOREIGN KEY (`MarkaId`) REFERENCES `marka` (`MarkaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele5` FOREIGN KEY (`DesenId`) REFERENCES `desen` (`DesenId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele6` FOREIGN KEY (`RenkId`) REFERENCES `renk` (`RenkId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_hebeladede` FOREIGN KEY (`TipId`) REFERENCES `tip` (`TipId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `kategori_ibfk_2` FOREIGN KEY (`RenkId`) REFERENCES `renk` (`RenkId`),
  ADD CONSTRAINT `kategori_ibfk_3` FOREIGN KEY (`DesenId`) REFERENCES `desen` (`DesenId`),
  ADD CONSTRAINT `kategori_ibfk_4` FOREIGN KEY (`MarkaId`) REFERENCES `marka` (`MarkaId`),
  ADD CONSTRAINT `kategori_ibfk_5` FOREIGN KEY (`BedenId`) REFERENCES `beden` (`BedenId`),
  ADD CONSTRAINT `kategori_ibfk_6` FOREIGN KEY (`KategoriAdId`) REFERENCES `kategoriad` (`KategoriAdId`);

--
-- Tablo kısıtlamaları `kullanici`
--
ALTER TABLE `kullanici`
  ADD CONSTRAINT `FK_users_role_map1213` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`PersonelId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `kullanici_ibfk_1` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`PersonelId`);

--
-- Tablo kısıtlamaları `magaza`
--
ALTER TABLE `magaza`
  ADD CONSTRAINT `FK_users_role_map2` FOREIGN KEY (`DepartmanId`) REFERENCES `departman` (`DepartmanId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `magaza_ibfk_1` FOREIGN KEY (`DepartmanId`) REFERENCES `departman` (`DepartmanId`);

--
-- Tablo kısıtlamaları `personel`
--
ALTER TABLE `personel`
  ADD CONSTRAINT `FK_users_role_ma2` FOREIGN KEY (`DepartmanId`) REFERENCES `departman` (`DepartmanId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_hebele` FOREIGN KEY (`MeslekId`) REFERENCES `meslek` (`MeslekId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_hebele1` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personel_ibfk_1` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`),
  ADD CONSTRAINT `personel_ibfk_2` FOREIGN KEY (`MeslekId`) REFERENCES `meslek` (`MeslekId`),
  ADD CONSTRAINT `personel_ibfk_3` FOREIGN KEY (`DepartmanId`) REFERENCES `departman` (`DepartmanId`);

--
-- Tablo kısıtlamaları `satis`
--
ALTER TABLE `satis`
  ADD CONSTRAINT `FK_heebele10` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`PersonelId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele8` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele9` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `satis_ibfk_1` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`),
  ADD CONSTRAINT `satis_ibfk_2` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`),
  ADD CONSTRAINT `satis_ibfk_3` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`PersonelId`);

--
-- Tablo kısıtlamaları `stok`
--
ALTER TABLE `stok`
  ADD CONSTRAINT `FK_heebele11` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_heebele12` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `stok_ibfk_1` FOREIGN KEY (`MagazaId`) REFERENCES `magaza` (`MagazaId`),
  ADD CONSTRAINT `stok_ibfk_2` FOREIGN KEY (`UrunId`) REFERENCES `urun` (`UrunId`);

--
-- Tablo kısıtlamaları `urun`
--
ALTER TABLE `urun`
  ADD CONSTRAINT `FK_users_role_1m1ap1` FOREIGN KEY (`KateoriId`) REFERENCES `kategori` (`KategoriId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `urun_ibfk_1` FOREIGN KEY (`KateoriId`) REFERENCES `kategori` (`KategoriId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
