# Customization-system

 Projeyi kendi yaptığım templatede oluşturdum. İçinde Dotween ve Odin asseti bulunuyor. Bunlar haricinde genelde kullandığım kodlar bulunuyor.

 Oyuna item ekleme mekaniğini scriptable üzerinden yaptım. Scripts>Customization klasörünün içinde bulunan Customization Data scriptable objesindeki listeye
 ekleme yapılması yeterli. "Name" itemin adı, "Customization Category" itemin kategorisi, "Item Type" itemin tipi, "Model" itemin prefabı, "UI Sprite" itemin uidaki gözükecek olan
 sprite'ı,"Textures" itemin eğer varsa texturelarını tutan liste, "Take Off Categories" ise item takıldığında modelin üstünden çıkarılacak kategorileri tutan liste şeklinde yaptım.
 Buraya ekleme yapılıp oyun doğrudan çalıştırılıp denenebilir.
 Customization Canvas objesinin childi olan Tabs objesindeki Tabs Manager scriptindeki Create Tabs ile tabler görüntülenebilir. 7 adet kategori ekledim. Eklenilen itemleri görmek için
 CustomizationItems objesindeki UIItemsManager scriptinde category seçilip Invoke butonuna basmak yeterli.

 Model prefabında bulunan CharacterAnimationController scripti üzerinden Dance state'i değiştirilirse itemların animasyonlarla uyumu da test edilebilir.

 Oyuna eklenen modele sağ tıklayıp CreateItem diyerekte scriptable objeye eklenebilir. 

 editor tool ekledim. _game>Prefabs klasörünün içindeki prefabları oyunu başlatmadan deneme şansı tanıyor. üst menüden cloth sekmesinden cloth test menuye tıklandığında
 scene ekranında menu açılıyor. bu klasorde bulunan prefablar menude gözüküyor. tıklandığında sahnedeki modelin üstünde oluşuyor. modelleme ve modeli karakter üzerinde
 görme aşaması için yararlı olacağını düşündüm.

 önceden her objede animator oluşuyordu. şuan objelerin skinned mesh rendererdaki bonelarını tekrar atayarak optimize ettim. sahnede tek animator var ve objeler bundan kemik bilgilerini çekip ona göre hareket ediyor.

 optimizasyon için adressable ekledim. 
