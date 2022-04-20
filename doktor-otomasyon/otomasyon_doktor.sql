-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 03 May 2021, 12:23:35
-- Sunucu sürümü: 8.0.23
-- PHP Sürümü: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `otomasyon_doktor`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `adres`
--

CREATE TABLE `adres` (
  `idadres` int NOT NULL,
  `il` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ilce` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `mahalle` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sokak` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `adres`
--

INSERT INTO `adres` (`idadres`, `il`, `ilce`, `mahalle`, `sokak`) VALUES
(1, 'Ankara', 'Yenimahalle', 'Emniyet', 'Bandırma'),
(2, 'Denizli', 'Pamukkale', 'Çınaraltı', 'Üniversite'),
(3, 'Kocaeli', 'İzmit', 'Kabaoğlu', 'Baki Komşuoğlu Bulvarı'),
(4, 'İstanbul', 'Sarıyer', 'Rumelifeneri', 'Sarıyer Rumeli Feneri'),
(5, 'Antalya', 'Konyaaltı', 'Pınarbaşı', 'Akdeniz Ünv'),
(6, 'İzmir', 'Bornova', 'Erzene', 'Ege Ünv'),
(7, 'İstanbul', 'Zeytinburnu', 'Maltepe', 'Teyyareci Sami'),
(8, 'İstanbul', 'Fatih', 'Beyazıt', 'Besim Öner Paşa'),
(9, 'Ankara', 'Çankaya', 'Üniversiteler', 'Hacettepe Kampüsü'),
(10, 'İstanbul', 'Beykoz', 'Kavacık', 'Ekinciler'),
(11, 'Ankara', 'Yenimahalle', 'Papatya', '123'),
(12, 'Denizli', 'Merkezefendi', 'Saltak', 'Atatürk'),
(13, 'Kocaeli', 'İzmit', 'Erenler', 'Cemre'),
(14, 'İstanbul', 'Ataşehir', 'Tatlısu', 'Şanlı'),
(15, 'Antalya', 'Kepez', 'Çiçek', 'Sıcaksu'),
(16, 'İzmir', 'Buca', 'Gazi', '1881'),
(17, 'İstanbul', 'Kadıköy', 'Yenisahra', '1907'),
(18, 'İstanbul', 'Beşiktaş', 'Dolmabahçe', '1903'),
(19, 'Ankara', 'Etimesgut', 'Göksu', 'Duranlar'),
(20, 'İstanbul', 'Avcılar', 'Selimiye', 'Sakarya'),
(21, 'İstanbul', 'Başakşehir', 'Bebek', 'Kazım Karabekir'),
(22, 'İstanbul', 'Güngören', 'Merter', 'Susam'),
(23, 'İstanbul', 'Fatih', 'Yenidoğan', '9873'),
(24, 'İstanbul', 'Fatih', 'Samatha', '5762'),
(25, 'İstanbul', 'Güngören', 'Kızılcık', 'Sular'),
(26, 'İstanbul', 'Şişli', 'Helvacılar', 'Şeker'),
(27, 'İstanbul', 'Ümraniye', 'Tatlısu', 'Esenli'),
(28, 'Ankara', 'Yenimahalle', 'Selanik', 'Yasin'),
(29, 'Ankara', 'Yenimahalle', 'Didem', 'Badem'),
(30, 'Ankara', 'Yenimahlle', 'Selanik', 'Fıstık'),
(31, 'Ankara', 'Etimesgut', 'Manavcılar', 'Meyve'),
(32, 'Ankara', 'Etimesgut', 'Akhan', '126'),
(33, 'Ankara', 'Etimesgut', 'Güzelkoy', 'Güzler'),
(34, 'Kocaeli', 'Derince', 'Şirinevler', 'Mustafa Kemal'),
(35, 'Antalya', 'Kemer', 'Çınar', '46'),
(36, 'Antalya', 'Alanya', 'Anahtarcılar', 'Altay'),
(37, 'Denizli', 'Pamukkale', 'Kale', '126'),
(38, 'İzmir', 'Foça', 'Alsancak', 'Limon'),
(39, 'İzmir', 'Menemen', 'Yorgancılar', 'Şeftali'),
(40, 'İzmir', 'Çeşme', 'Boyozcular', 'Gevrek'),
(41, 'Denizli', 'Serinhisar', 'Axxxx', 'Bxxxx');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `asi`
--

CREATE TABLE `asi` (
  `idasi` int NOT NULL,
  `asi_adi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `asi`
--

INSERT INTO `asi` (`idasi`, `asi_adi`) VALUES
(1, 'BioNTech'),
(2, 'Grip'),
(3, 'Kızamık'),
(4, 'Hepatit A'),
(5, 'Hepatit B'),
(6, 'Su Çiçeği'),
(7, 'Mevsimsel İnfluenza'),
(8, 'Difteri Tetanoz'),
(9, 'Sinovac'),
(10, 'Sputnik V');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `brans`
--

CREATE TABLE `brans` (
  `idbrans` int NOT NULL,
  `brans_adi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `brans`
--

INSERT INTO `brans` (`idbrans`, `brans_adi`) VALUES
(1, 'Çocuk Doktoru'),
(2, 'Diş Hekimi'),
(3, 'Kadın Doğum Hastalıkları'),
(4, 'Dahiliye'),
(5, 'Genel Cerrahi'),
(6, 'Dermatoloji'),
(7, 'Nöroloji'),
(8, 'Üroloji'),
(9, 'Göz Hastalıkları'),
(10, 'Kulak Burun Boğaz');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `doktor`
--

CREATE TABLE `doktor` (
  `iddoktor` int NOT NULL,
  `doktor_adi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `doktor_soyadi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `doktor_unvan` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `doktor_tc` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `doktor_dogum_tarihi` date NOT NULL,
  `doktor_izin` int NOT NULL,
  `idhastane` int NOT NULL,
  `idbrans` int NOT NULL,
  `iddokul` int NOT NULL,
  `idadres` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `doktor`
--

INSERT INTO `doktor` (`iddoktor`, `doktor_adi`, `doktor_soyadi`, `doktor_unvan`, `doktor_tc`, `doktor_dogum_tarihi`, `doktor_izin`, `idhastane`, `idbrans`, `iddokul`, `idadres`) VALUES
(1, 'Oğuz', 'Çetinkaya', 'Uzman', '10000000001', '1986-12-04', 40, 1, 9, 2, 11),
(2, 'Batuhan', 'Aral', 'Profesör', '10000000002', '1988-07-03', 35, 2, 4, 8, 12),
(3, 'Alperen', 'Kuzhan', 'Diş Hekimi', '10000000003', '1965-12-05', 23, 3, 2, 4, 13),
(4, 'Bera', 'Avşar', 'Operatör', '10000000004', '1970-05-20', 17, 4, 6, 3, 14),
(5, 'Recep', 'Tuğrul', 'Profesör', '10000000005', '1967-04-18', 20, 5, 7, 9, 15),
(6, 'Ziya', 'Başkaya', 'Yardımcı Doçent', '10000000006', '1972-08-06', 38, 6, 8, 1, 16),
(7, 'Fatma', 'Coşkun', 'Pratisyen', '10000000007', '1977-03-23', 31, 7, 10, 2, 17),
(8, 'Eymen', 'Doğan', 'Doçent', '10000000008', '1980-08-06', 27, 8, 3, 6, 18),
(9, 'Sıla', 'Akçay', 'Profesör', '10000000009', '1960-11-11', 13, 9, 5, 5, 19),
(10, 'Merve', 'Emer', 'Profesör', '10000000010', '1962-09-01', 2, 10, 6, 5, 20),
(11, 'Tuncay', 'Gezer', 'Asistan', '10000000011', '1982-07-26', 40, 10, 1, 10, 21),
(12, 'Aliberk', 'Asmadil', 'Başasistan', '10000000012', '1975-11-23', 35, 7, 3, 4, 22),
(13, 'Veysel', 'Çetinkaya', 'Profesör', '10000000013', '1960-02-24', 31, 4, 5, 1, 23),
(14, 'Mehmet', 'Koca', 'Doçent', '10000000014', '1970-03-24', 28, 8, 9, 5, 24),
(15, 'Zeynep', 'Bilen', 'Pratisyen', '10000000015', '1985-07-06', 37, 4, 7, 7, 25),
(16, 'Fikri', 'Şimşek', 'Pratisyen', '10000000016', '1980-09-19', 14, 10, 10, 9, 26),
(17, 'Merve', 'Köse', 'Diş Hekimi', '10000000017', '1975-05-15', 16, 7, 2, 8, 27),
(18, 'Şükrü', 'Saraç', 'Uzman', '10000000018', '1988-07-30', 7, 1, 4, 4, 28),
(19, 'Umut', 'Çınar', 'Profesör', '10000000019', '1967-08-31', 40, 9, 6, 6, 29),
(20, 'Efe', 'İdi', 'Operatör', '10000000020', '1959-10-29', 32, 1, 8, 2, 30),
(21, 'Atakan', 'Avcı', 'Yardımcı Doçent', '10000000021', '1972-01-01', 36, 1, 7, 1, 31),
(22, 'Berkant', 'Yıldız', 'Doçent', '10000000022', '1970-12-04', 24, 9, 3, 3, 32),
(23, 'Melih', 'Yıldız', 'Ordinasyüs', '10000000023', '1943-01-02', 13, 1, 1, 7, 33),
(24, 'Fethi', 'Maraşlı', 'Uzman', '10000000024', '1990-12-17', 18, 3, 4, 9, 34),
(25, 'Tuğçe', 'Sancak', 'Asistan', '10000000025', '1993-08-05', 20, 5, 10, 10, 35),
(26, 'Simay', 'Ay', 'Diş Hekimi', '10000000026', '1983-03-17', 31, 5, 2, 10, 36),
(27, 'Ayşegül', 'Tulum', 'Başasistan', '10000000027', '1992-02-22', 19, 2, 5, 4, 37),
(28, 'Hayriye', 'Gül', 'Pratisyen', '10000000028', '1995-05-21', 28, 6, 5, 8, 38),
(29, 'Banu', 'Bayram', 'Operatör', '10000000029', '1977-04-28', 29, 6, 9, 6, 39),
(30, 'Ayten', 'Hasusta', 'Diş Hekimi', '10000000030', '1971-12-15', 30, 6, 2, 2, 40),
(31, 'Xaaa', 'Xbbb', 'Doçent', '10012537852', '2021-05-20', 27, 5, 2, 4, 41);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `doktor_asi_vurulur`
--

CREATE TABLE `doktor_asi_vurulur` (
  `doktor_iddoktor` int NOT NULL,
  `asi_idasi` int NOT NULL,
  `tarih` date NOT NULL,
  `doz` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hastane`
--

CREATE TABLE `hastane` (
  `idhastane` int NOT NULL,
  `hastane_adi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `hastane_turu` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `idadres` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `hastane`
--

INSERT INTO `hastane` (`idhastane`, `hastane_adi`, `hastane_turu`, `idadres`) VALUES
(1, 'Ortadoğu Hastanesi', 'Özel', 1),
(2, 'Servergazi Hastanesi', 'Devlet', 2),
(3, 'Konak Hastanesi', 'Özel', 3),
(4, 'İsmail Akgün Hastanesi', 'Devlet', 4),
(5, 'Memorial Antalya Hastanesi', 'Devlet', 5),
(6, 'Türkan Özilhan Hastanesi', 'Devlet', 6),
(7, 'Sante Plus Hastanesi', 'Özel', 7),
(8, 'Haseki Eğitim ve Araştırma Hastanesi', 'Devlet', 8),
(9, 'Çankaya Hastanesi', 'Özel', 9),
(10, 'Beykoz Devlet Hastanesi', 'Devlet', 10);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `izin`
--

CREATE TABLE `izin` (
  `idizin` int NOT NULL,
  `izin_baslangic` date NOT NULL,
  `izin_bitis` date NOT NULL,
  `iddoktor` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `izin`
--

INSERT INTO `izin` (`idizin`, `izin_baslangic`, `izin_bitis`, `iddoktor`) VALUES
(1, '2021-03-10', '2021-03-12', 3),
(2, '2021-05-10', '2021-05-12', 31),
(3, '2021-05-13', '2021-05-14', 31),
(4, '2021-05-10', '2021-05-15', 31),
(5, '2021-05-10', '2021-05-14', 31),
(6, '2021-05-12', '2021-05-21', 31);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nobet`
--

CREATE TABLE `nobet` (
  `idnobet` int NOT NULL,
  `nobet_tarihi` date NOT NULL,
  `iddoktor` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `nobet`
--

INSERT INTO `nobet` (`idnobet`, `nobet_tarihi`, `iddoktor`) VALUES
(1, '2021-04-12', 3),
(2, '2021-04-11', 1),
(3, '2021-04-10', 2),
(4, '2021-05-02', 31);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `okul`
--

CREATE TABLE `okul` (
  `idokul` int NOT NULL,
  `okul_adi` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `okul_turu` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `okul`
--

INSERT INTO `okul` (`idokul`, `okul_adi`, `okul_turu`) VALUES
(1, 'Gazi Üniversitesi', 'Devlet'),
(2, 'Pamukkale Üniversitesi', 'Devlet'),
(3, 'Kocaeli Üniversitesi', 'Devlet'),
(4, 'Koç Üniversitesi', 'Özel'),
(5, 'Akdeniz Üniversitesi', 'Devlet'),
(6, 'Ege Üniversitesi', 'Devlet'),
(7, 'İstinye Üniversitesi', 'Özel'),
(8, 'İstanbul Üniversitesi', 'Devlet'),
(9, 'Hacettepe Üniversitesi', 'Devlet'),
(10, 'Medipol Üniversitesi', 'Özel');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `adres`
--
ALTER TABLE `adres`
  ADD PRIMARY KEY (`idadres`);

--
-- Tablo için indeksler `asi`
--
ALTER TABLE `asi`
  ADD PRIMARY KEY (`idasi`);

--
-- Tablo için indeksler `brans`
--
ALTER TABLE `brans`
  ADD PRIMARY KEY (`idbrans`);

--
-- Tablo için indeksler `doktor`
--
ALTER TABLE `doktor`
  ADD PRIMARY KEY (`iddoktor`),
  ADD UNIQUE KEY `doktor_tc_UNIQUE` (`doktor_tc`),
  ADD KEY `fk_hastane_doktor_idx` (`idhastane`),
  ADD KEY `fk_brans_doktor_idx` (`idbrans`),
  ADD KEY `fk_okul_doktor_idx` (`iddokul`),
  ADD KEY `fk_doktor_adres1_idx` (`idadres`);

--
-- Tablo için indeksler `doktor_asi_vurulur`
--
ALTER TABLE `doktor_asi_vurulur`
  ADD KEY `fk_doktor_has_asi_asi1_idx` (`asi_idasi`),
  ADD KEY `fk_doktor_has_asi_doktor1_idx` (`doktor_iddoktor`);

--
-- Tablo için indeksler `hastane`
--
ALTER TABLE `hastane`
  ADD PRIMARY KEY (`idhastane`),
  ADD KEY `fk_hastane_adres1_idx` (`idadres`);

--
-- Tablo için indeksler `izin`
--
ALTER TABLE `izin`
  ADD PRIMARY KEY (`idizin`),
  ADD KEY `fk_izin_doktor1_idx` (`iddoktor`);

--
-- Tablo için indeksler `nobet`
--
ALTER TABLE `nobet`
  ADD PRIMARY KEY (`idnobet`),
  ADD KEY `fk_nobet_doktor1_idx` (`iddoktor`);

--
-- Tablo için indeksler `okul`
--
ALTER TABLE `okul`
  ADD PRIMARY KEY (`idokul`);

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `doktor`
--
ALTER TABLE `doktor`
  ADD CONSTRAINT `fk_doktor_adres` FOREIGN KEY (`idadres`) REFERENCES `adres` (`idadres`),
  ADD CONSTRAINT `fk_doktor_brans` FOREIGN KEY (`idbrans`) REFERENCES `brans` (`idbrans`),
  ADD CONSTRAINT `fk_doktor_hastane` FOREIGN KEY (`idhastane`) REFERENCES `hastane` (`idhastane`),
  ADD CONSTRAINT `fk_doktor_okul` FOREIGN KEY (`iddokul`) REFERENCES `okul` (`idokul`);

--
-- Tablo kısıtlamaları `doktor_asi_vurulur`
--
ALTER TABLE `doktor_asi_vurulur`
  ADD CONSTRAINT `fk_doktor_has_asi_asi` FOREIGN KEY (`asi_idasi`) REFERENCES `asi` (`idasi`),
  ADD CONSTRAINT `fk_doktor_has_asi_doktor` FOREIGN KEY (`doktor_iddoktor`) REFERENCES `doktor` (`iddoktor`);

--
-- Tablo kısıtlamaları `hastane`
--
ALTER TABLE `hastane`
  ADD CONSTRAINT `fk_hastane_adres` FOREIGN KEY (`idadres`) REFERENCES `adres` (`idadres`);

--
-- Tablo kısıtlamaları `izin`
--
ALTER TABLE `izin`
  ADD CONSTRAINT `fk_izin_doktor` FOREIGN KEY (`iddoktor`) REFERENCES `doktor` (`iddoktor`);

--
-- Tablo kısıtlamaları `nobet`
--
ALTER TABLE `nobet`
  ADD CONSTRAINT `fk_nobet_doktor` FOREIGN KEY (`iddoktor`) REFERENCES `doktor` (`iddoktor`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
