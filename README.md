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
