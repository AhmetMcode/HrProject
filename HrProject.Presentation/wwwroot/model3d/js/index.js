class ThreeUtils {
	
    static setupApp({containerid = 'container', grid = true} = {}){
		
		var vincKirisiSayisi = 0;
		var kolonSayisi = 16;
		var ruzgarKolonSayisi = 2;
		var tumStandSayisi = 18;
		var olukSayisi = 14;
		var makasSayisi = 8;
		var KompleAraKatHolSayisi = 0;
		var KompleAraKatHolBoyutu = 0;
		var kismiAraKatHolSayisi = 0;
		var kismiAraKatAksSayisi = 0;
		var kismiAraKatHolBoyutu = 0;
		var kismiAraKatAksBoyutu = 0;
		var genelHolSayisi = 1;
		var asikSayisi = 12;
		var vincKirisYeriEn = 'A-B';
		var vincKirisYeriBoy = '1-7';
		var araKatYeriEn = 'A-B';
		var araKatYeriBoy = '1-7';
		var ttPlak = 0;
		var taliKiris = 0;
		var arakatKiris = 0;
		var arakatKolon = 0;
		var butunParcalar = 0;
		var toplamMetreKup = 0;
		
		var ongermeHalatiOluk = 0;
		var ongermeHalatiAsik = 0;
		var ongermeHalatiAraKatKiris = 0;
		var ongermeHalatiPiplak = 0;
		var ongermeHalatiMakas = 0;
		var ongermeHalatiToplam = 0;
		var ongermeHalatiKarkas = 0;
		
		var ankrajToplam = 0;
		
		//ttplak
		var ttPlakMetreKup30 = 0;
		var ttPlakMetreKup45 = 0;
		var ttPlakMetreKup70 = 0;
		var ttPlakYukseklik3045 = 0.05;
		var ttPlakYukseklik70 = 0.1;

		//kolonlar
		var taneKolonMetreKup = 4;//3.5
		var taneKolonMetreKup2 = 3.5;
		var kolonMetreKup = 0;
		
		//rüzgar kolonlar
		var taneRuzgarKolonMetreKup = 3;//2.11
		var taneRuzgarKolonMetreKup2 = 2.11;
		
		var arakatKolonMetreküp = 3;//2.11
		var arakatKolonMetreküp2 = 2.11;
		var arakatKolonMetreküpAdet = 0;
		
		//makaslar
		var taneMakasMetreKup = 6.1;//5.78
		var taneMakasMetreKup2 = 5.78;
		var makasMetreKup = 0;
		
		//asiklar
		var taneAsikMetreKup = 0.8;//0.23
		var taneAsikMetreKup2 = 0.23;
		var asikMetreKupT = 0;
		
		//oluk kirisi
		var taneOlukMetreKup = 1;//0.77
		var taneOlukMetreKup2 = 0.77;
		var olukMetreKup = 0;
		
		//vinç kirisi
		var taneVincMetreKup = 2.3;//1.5
		var taneVincMetreKup2 = 1.5;
		var vincKirisiMetreKup = 0;
				
        ThreeUtils.app = {};
        var app = ThreeUtils.app;
        app.container = document.getElementById(containerid);
        app.renderer = ThreeUtils.setupRenderer(app.container);

        app.scene = new THREE.Scene();
        var group = new THREE.Group();
        app.scene.add(group);
		var light1 = new THREE.DirectionalLight(0xFFFFFF, 1);
		light1.position.set(-100, -80, -150);
        var light = new THREE.DirectionalLight(0xFFFFFF, 1);
        light.position.set(100, 80, 130);
        group.add(light);
		group.add(light1);

        var size = app.renderer.getSize();
        app.camera = new THREE.PerspectiveCamera(45, size.width / size.height, 1, 1000);
        app.camera.position.set(- 40, 30, 100);
		
        app.controls = new THREE.TrackballControls(app.camera, app.renderer.domElement);

		//mouse ile hareket için controls.
		app.controls.rotateSpeed = 0.9;
		app.controls.panSpeed = 0.5;
		app.controls.zoomSpeed = 0.9;
		//mouse-right button
		
		//app.controls.noZoom = false;
		app.controls.noPan = false;
		app.controls.staticMoving = true;
		app.controls.dynamicDampingFactor = 0.1;
		
		var geometry = new THREE.BoxGeometry(5, 5, 5);

        window.addEventListener('resize', ThreeUtils.onWindowResize, false);
			
        var Settings = function(){
				
            this.VincliKolonlar = false,
			this.Vinc_Kirisleri_Ekle = false,
			this.AraKatEkle = false,
			this.KismiAraKatEkle = false,
			this.kismiAraKatKaldir = false,
			this.araKatUzunlugu = 1,
			this.araKatGenisligi = 1,
            this.Boy = 73,
            this.En = 43,
			this.Yükseklik = 13,
            this.stepBoy = 13, //with number
            this.stepEn = 20, //with alpha-beta
            this.a = 0,
            this.b = 0,
			this.ruzgarKolonSayisi = 2,
			this.vincsizKolonSayisi = 16,
			this.vincKirisiSayisi = 0,
			this.olukSayisi = 14,
			this.makasSayisi = 8,
			this.kolonStandSayisi = 18,
			this.asikSayisi = 12,
			this.araKatSayisi = 0,
			this.KismiaraKatSayisi = 0,
				
            this.redraw = function(){

				settings.EkranResetleme();
				//settings.objeSayisiniBul();
                this.stepBoy = parseFloat(this.Boy / (Math.ceil(this.Boy / 10)));
                this.stepEn  = parseFloat(this.En / ((this.En / 30) + 1));

				app.grid = new LabeledGrid(60, 20, (60 / (60 / 10)), (60 / ((60 / 30) + 1)), 13, [0,1,0], 0x000055, 0.21, true, "#000000", "left");
				app.scene.add(app.grid);
				//return app;

				this.stepEn = this.stepEn + ((this.En % this.stepEn) / (this.En / this.stepEn));
				
				//this.stepBoy = this.stepBoy + ((this.Boy % this.stepBoy) / (this.Boy / this.stepBoy));
				
				/*if(this.stepBoy < 7.1){
					
					this.stepBoy = parseFloat(19 / ((19 / 9.54) + 1));
					this.stepBoy = this.stepBoy + ((19 % this.stepBoy) / (19 / this.stepBoy));
				}*/
				
                app.grid.resize(this.Boy, this.En, this.stepBoy.toFixed(2), this.stepEn.toFixed(2), this.Yükseklik);
				
				settings.RuzgarKolonlariEkle();
				
				if(this.AraKatEkle === true){
					
					settings.AraKatEkleme();
				}
				
				else{
					
					settings.AraKatKaldir();
				}
				
				if(this.VincliKolonlar === true){
					
					settings.VincKirisleriKaldir();
					settings.kolEkle();
				}

				else{

					settings.VincsizKolonEkle();
				}

				//GUI vinç kirişleri aktif mi?
				if(this.Vinc_Kirisleri_Ekle === true){
					
					settings.VincKirisiEkle();
				}

				else{
					
					settings.VincKirisleriKaldir();
				}
				
				genelHolSayisi = Math.round((settings.En - (settings.En % settings.stepEn)) / settings.stepEn);
				
				//console.log(genelHolSayisi);
				
				var group = new THREE.Group();
				var light1 = new THREE.DirectionalLight(0xFFFFFF, 1);
				light1.position.set(-100, -80, -150);
				var light = new THREE.DirectionalLight(0xFFFFFF, 1);
				light.position.set(100, 80, 130);
				group.add(light);
				group.add(light1);
				app.scene.add(group);
			};
			//Obje eklemeler başlangıç*
			
			//vinçli kolon ekleme
			this.kolEkle = function(){
				
				//orta kolon kontrolü, varsa fonksiyona git.
				if(settings.En / settings.stepEn > 1){
						
					this.VincliOrtaKolonEkle();
				}
				
				else{
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
					this.makasEkle();
					this.olukEkle();
					this.asikEkle();
					settings.KolonAltObjEkle();
					//this.VincKirisiEkle();
					
					if(this.AraKatEkle === false){
					
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincliKenarKolon14.obj', function(data){

							for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

								var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
								app.scene.remove(selectedItem);
								var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(2.7 + (settings.En * 1), 0, 5 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "VincliKenarKolonEkleX" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(-2.9, 0, -5 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "VincliKenarKolonEkleY" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
						},
							function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
							//if download fails
							function(xhr){

							// console.error('An error happened : ' + xhr);
							}
						);
					}
					//arakat vinçli kenar kolonlarını ekleme kısmı
					else{
						
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincliKenarKolon.obj', function(data){

							for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

								var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
								app.scene.remove(selectedItem);
								var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(0 + (settings.En * 1), 0, 0.32 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "VincliKenarKolonEkleX" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, - 0.43 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "VincliKenarKolonEkleY" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

							}
						},
							function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
							//if download fails
							function(xhr){

							// console.error('An error happened : ' + xhr);
							}
						);
					}
				}
			}
			//vinçsiz kolon ekleme fonksiyonu
			this.VincsizKolonEkle = function(){

				//orta kolon kontrolü, varsa fonksiyona git.
				if(settings.En / settings.stepEn > 1){
						
					this.VincsizOrtaKolonEkle();
				}
				
				else{
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var mtlLoader = new THREE.MTLLoader();
					var objLoader = new THREE.OBJLoader();
					var fileloader = new THREE.FileLoader();
					
					this.makasEkle();
					this.olukEkle();
					this.asikEkle();
					settings.KolonAltObjEkle();
					settings.VincKirisleriKaldir();
					
					//rüzgar kolonlarının alt standlarını oluşturma.
												
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){
												
						for(var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)) - 1; i++){
						
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltÖn" + i);
							app.scene.remove(selectedItem);
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltArka" + i);
							app.scene.remove(selectedItem);
							                                        
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, 0, - 2.1);
							object.name = "RuzgarKolonAltÖn" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){
									
								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, 0, - 1.95 - (settings.Boy));
							object.name = "RuzgarKolonAltArka" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){
									
								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							
							app.scene.add(object);
						}
                    },
                        function(xhr){
 
                          //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function(xhr){

                           //console.error('An error happened : ' + xhr);
                        }
                    );
					
					//***rüzgar kolonlarını oluşturma ve ekleme.
					for (var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)) - 1; i++){
						
						var selectedItem1 = app.scene.getObjectByName("araKatÖn" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("araKatArka" + i);
						app.scene.remove(selectedItem1);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 2.25) , 0);
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatÖn" + i;
						object.receiveShadow = true;
						app.scene.add(object);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 2.25), - (settings.Boy));
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatArka" + i;
						object.receiveShadow = true;
						app.scene.add(object);
					}
					
					
					if(this.AraKatEkle === false){
						
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincsizKenarKolon.obj', function(data){
						
						//console.log("stepEn kolon fonk içinde: " + settings.stepBoy);						
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){
							
							//scene'deki objeleri isme göre bulup eskilerini sil
							var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
							app.scene.remove(selectedItem);
							var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
							app.scene.remove(selectedItem1);
                                        
							var object = loader.parse(data);
							object.position.set(2.5 + (settings.En * 1), 0, 5 - (settings.stepBoy * i));
							object.rotateY(-1.6);
							object.name = "VincsizKenarKolonX" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);
							
							var object = loader.parse(data);
							object.position.set(-2.7, 0, -5 - (settings.stepBoy * i));
							object.rotateY(1.58);
							object.name = "VincsizKenarKolonY" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);
						}
                    },
                        function(xhr){
						   //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                           //Objenin indirilmesinde hata olur ise
                        function(xhr){
                           console.error('An error happened : ' + xhr);
                        }
                    );
					}
					
					//araKat ekleme açık ise kolonları değiştir.
					else{
						
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatKenarKolonSon.obj', function(data){
						
							//console.log("stepEn kolon fonk içinde: " + settings.stepBoy);						
							for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

								//scene'deki objeleri isme göre bulup eskilerini sil
								var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
								app.scene.remove(selectedItem);
								var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(0 + (settings.En * 1), 0, 0.32 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "AraKatKenarKolonX" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, - 0.43 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "AraKatKenarKolonY" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
                    	},
							function(xhr){
							   //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
							   //Objenin indirilmesinde hata olur ise
							function(xhr){
							   console.error('An error happened : ' + xhr);
							}
                    	);
					}
				}
			}
			//makas ekleme fonk
			this.makasEkle = function(){
				
				if(settings.En / settings.stepEn > 1){
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
					//gui değiştikten sonra, en'e göre soldan ilk makaslar.
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/makasD1.obj', function(data){
					
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){
							
							var selectedItem1 = app.scene.getObjectByName("makasIlk" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("makasElse" + i);
							app.scene.remove(selectedItem1);

							var object = loader.parse(data);
							object.position.set(0 + (settings.stepEn / 2), settings.Yükseklik / 1.15, 5 - (settings.stepBoy * i));
							object.rotateY(-1.58);
							object.name = "makasIlk" + i;
							object.scale.set(0.21, 0.2, settings.stepEn / 105);
							app.scene.add(object);
						}
                    },
                        function (xhr) {
                        
                            //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function (xhr) {
                        
                           // console.error('An error happened : ' + xhr);
                        }
                    );
					
					//iki for ile x ve y ekseninde çoğalan makaslar oluşturuluyor.
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/makasD1.obj', function(data){
												
							for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){
									
								// arta kalan bir bölüm yoksa bu kısma girilecek.
								if(settings.En % settings.stepEn === 0){
									
									for(var j = 0; j < (settings.En / settings.stepEn) - 1; j++){

										var selectedItem1 = app.scene.getObjectByName("makas" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(0 + (settings.stepEn / 2) + (settings.stepEn * (j + 1)), settings.Yükseklik / 1.15, 5 - (settings.stepBoy * i));
										object.rotateY(-1.58);
										object.name = "makas" + i + j;
										object.scale.set(0.2, 0.2, settings.stepEn / 104);
										app.scene.add(object);
									}
								}
								
								else{
									
									for(var j = 0; j < (settings.En / settings.stepEn) - 2; j++){

										var selectedItem1 = app.scene.getObjectByName("makas" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(0 + (settings.stepEn / 2) + (settings.stepEn * (j + 1)), settings.Yükseklik / 1.15, 5 - (settings.stepBoy * i));
										object.rotateY(-1.58);
										object.name = "makas" + i + j;
										object.scale.set(0.2, 0.2, settings.stepEn / 104);
										app.scene.add(object);
									}
								}
							}
                    },
                        function(xhr){
 
                           // console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function(xhr){
                        
                           // console.error('An error happened : ' + xhr);
                        }
                    );
				}
				
				else{
					
				var manager = new THREE.LoadingManager();
				var loader = new THREE.OBJLoader(manager);
				var fileloader = new THREE.FileLoader();
				
				fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/makasD1.obj', function(data){
					
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){
							
							var selectedItem1 = app.scene.getObjectByName("makasElse" + i);
							app.scene.remove(selectedItem1);

							var object = loader.parse(data);
							object.position.set(0 + (settings.stepEn / 2), settings.Yükseklik / 1.15, 4.8 - (settings.stepBoy * i));
							object.rotateY(-1.58);
							object.name = "makasElse" + i;
							object.transparent = true;
							object.opacity = 0.1;
							object.scale.set(0.2, 0.2, 0.19);
							//console.log(object)
							app.scene.add(object);
						}
                    },
                        function (xhr){
                        
                            //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function (xhr){
                        
                           // console.error('An error happened : ' + xhr);
                        }
                    );
				}
			}
			//kolon alt objelerinin eklenmesi
			this.KolonAltObjEkle = function(){
				
				var manager = new THREE.LoadingManager();
				var mtlLoader = new THREE.MTLLoader();
				var objLoader = new THREE.OBJLoader();
				var fileloader = new THREE.FileLoader();
				var objLoader = new THREE.OBJLoader(manager);
				
				if(settings.En / settings.stepEn > 1){

					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){
												
					for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

						if(settings.En % settings.stepEn === 0){
								
							for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){

								var selectedItem1 = app.scene.getObjectByName("z" + i + j);
								//app.scene.remove(selectedItem1);
								
								var object = objLoader.parse(data);
								object.position.set((settings.stepEn * (j + 1)), 0, - 2 - (settings.stepBoy * i));
								object.name = "kolonAltlik" + i + j;
								object.scale.set(0.21, 0.21, 0.21);
								object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
								});
								app.scene.add(object);
							}
							 
							
							if(settings.AraKatEkle === true){
								
								if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
									
									for(var j = 0; j < ((settings.En / (settings.stepEn / 3)) - 1); j++){

										var object = objLoader.parse(data);
										object.position.set(((settings.stepEn / 3) * (j + 1)), 0, - 2 - (settings.stepBoy * i));
										object.name = "kolonAltlikAraKat" + i + j;
										object.scale.set(0.21, 0.21, 0.21);
										object.traverse(function (child){

										if(child instanceof THREE.Mesh)
											child.material.color.setHex(0x969696);
										});
										app.scene.add(object);
									}
								}
								
								else{
									
									for(var j = 0; j < ((settings.En / (settings.stepEn / 2)) - 1); j++){

										var object = objLoader.parse(data);
										object.position.set(((settings.stepEn / 2) * (j + 1)), 0, - 2 - (settings.stepBoy * i));
										object.name = "kolonAltlikAraKat" + i + j;
										object.scale.set(0.21, 0.21, 0.21);
										object.traverse(function (child){

										if(child instanceof THREE.Mesh)
											child.material.color.setHex(0x969696);
										});
										app.scene.add(object);
									}
								}
							}
						}
						//en ara sayılar olduğunda orta kolon altlarını oluşturmak
						else{
							
							for(var j = 0; j < ((settings.En / (settings.stepEn)) - 2); j++){

								var selectedItem1 = app.scene.getObjectByName("z" + i + j);
								//app.scene.remove(selectedItem1);

								var object = objLoader.parse(data);
								object.position.set((settings.stepEn * (j + 1)), 0, - 2 - (settings.stepBoy * i));
								object.name = "kolonAltlik" + i + j;
								object.scale.set(0.21, 0.21, 0.21);
								object.traverse(function (child){

									if(child instanceof THREE.Mesh)
										child.material.color.setHex(0x969696);
								});
								app.scene.add(object);
							}
							
							if(settings.AraKatEkle === true){
								
								if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
								
									for(var j = 0; j < ((settings.En / (settings.stepEn / 3)) - 2); j++){

										var object = objLoader.parse(data);
										object.position.set(((settings.stepEn / 3) * (j + 1)), 0, - 2 - (settings.stepBoy * i));
										object.name = "kolonAltlikAraKat" + i + j;
										object.scale.set(0.21, 0.21, 0.21);
										object.traverse(function (child){

										if(child instanceof THREE.Mesh)
											child.material.color.setHex(0x969696);
										});
										app.scene.add(object);
									}
								}
								
								else{
									
									for(var j = 0; j < ((settings.En / (settings.stepEn / 2)) - 2); j++){

										var object = objLoader.parse(data);
										object.position.set(((settings.stepEn / 2) * (j + 1)), 0, - 2 - (settings.stepBoy * i));
										object.name = "kolonAltlikAraKat" + i + j;
										object.scale.set(0.21, 0.21, 0.21);
										object.traverse(function (child){

										if(child instanceof THREE.Mesh)
											child.material.color.setHex(0x969696);
										});
										app.scene.add(object);
									}
								}
							}
						}
					}
                },
                	function(xhr){
 
                		// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                	},
                          //if download fails
                	function(xhr){

                           // console.error('An error happened : ' + xhr);
                	}
                );
					//gui değiştiğinde kenar kolon altlarını oluşturma
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){

						var selectedItem1 = app.scene.getObjectByName("kolonAltlikSag" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("kolonAltlikSol" + i);
						app.scene.remove(selectedItem1);

						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

							var object = objLoader.parse(data);
							object.position.set((settings.En - (settings.En % settings.stepEn)), 0,  - 2 -(settings.stepBoy * i));
							object.name = "kolonAltlikSag" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);

							var object = objLoader.parse(data);
							object.position.set(0, 0,  - 2.3 -(settings.stepBoy * i));
							object.name = "kolonAltlikSol" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);

						}
					},
						function(xhr){

						//console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
						//if download fails
						function(xhr){

							   // console.error('An error happened : ' + xhr);
						}
					);	
				}

				else{
					
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){
						
						var selectedItem1 = app.scene.getObjectByName("kolonAltlikSag" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("kolonAltlikSol" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("kolonAltlikOrta" + i);
						app.scene.remove(selectedItem1);
												
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){
							
							var object = objLoader.parse(data);
							object.position.set(0 + (settings.En - (settings.En % settings.stepEn)), 0,  - 1.9 - (settings.stepBoy * i));
							object.name = "kolonAltlikSag" + i;
							object.scale.set(0.2, 0.2, 0.2);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);

							var object = objLoader.parse(data);
							object.position.set(0, 0,  - 2.2 - (settings.stepBoy * i));
							object.name = "kolonAltlikSol" + i;
							object.scale.set(0.2, 0.2, 0.2);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
							var object = objLoader.parse(data);
							object.position.set(10, 0, - 1.9 - (settings.stepBoy * i));
							object.name = "kolonAltlikOrta" + i;
							object.scale.set(0.2, 0.2, 0.2);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							if(settings.AraKatEkle === true){
								
								app.scene.add(object);
							}
						}
					},
						function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
							  //if download fails
						function(xhr){

							   // console.error('An error happened : ' + xhr);
						}
					);	
				}
			}
			//aşık ekleme	
			this.asikEkle = function(){
				
				if(settings.En / settings.stepEn > 1){
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);                
					var fileloader = new THREE.FileLoader();
					
					for(var i = 0; i < (settings.En / settings.stepEn) * 9; i++){
							
							var selectedItem1 = app.scene.getObjectByName("asik" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("asik1" + i);
							app.scene.remove(selectedItem1);
						}

					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/asikust1.obj', function(data){
						
						for(var i = 0; i < (settings.stepEn / 2 / 1.95); i++){
							
								var selectedItem1 = app.scene.getObjectByName("asik" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("asik1" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("asik4" + i + j);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("asik5" + i + j);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(((settings.stepEn / 2) + 0.4) + (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
								object.rotateY(0);
								object.name = "asik4" + i + j;
								object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(((settings.stepEn / 2) - 0.2) - (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
								object.rotateY(0);
								object.name = "asik5" + i + j;
								object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
								app.scene.add(object);

							}
						
						if(settings.En % settings.stepEn === 0){
							
							for(var j = 1; j < (settings.En / settings.stepEn); j++){

								for(var i = 0; i < (settings.stepEn / 2 / 1.95); i++){

									var selectedItem1 = app.scene.getObjectByName("asik" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik1" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik2" + i + j);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik3" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(((settings.stepEn / 2) + 0.4) + (settings.stepEn * j) + (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
									object.rotateY(0);
									object.name = "asik2" + i + j;
									object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
									app.scene.add(object);

									var object = loader.parse(data);
									object.position.set(((settings.stepEn / 2) - 0.1) + (settings.stepEn * j) - (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
									object.rotateY(0);
									object.name = "asik3" + i + j;
									object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
									app.scene.add(object);

								}
							}
						}
						
						else{
							
							for(var j = 1; j < (settings.En / settings.stepEn) - 1; j++){

								for(var i = 0; i < (settings.stepEn / 2 / 1.95); i++){

									var selectedItem1 = app.scene.getObjectByName("asik" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik1" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik2" + i + j);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("asik3" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(((settings.stepEn / 2) + 0.4) + (settings.stepEn * j) + (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
									object.rotateY(0);
									object.name = "asik2" + i + j;
									object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
									app.scene.add(object);

									var object = loader.parse(data);
									object.position.set(((settings.stepEn / 2) - 0.1) + (settings.stepEn * j) - (1.88 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
									object.rotateY(0);
									object.name = "asik3" + i + j;
									object.scale.set(0.3, 0.5, ((settings.Boy) / 15.7));
									app.scene.add(object);

								}
							}
						}
						},
							function (xhr) {

								//console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
							  //if download fails
							function (xhr) {

							   // console.error('An error happened : ' + xhr);
							}
					);
				}
				//ilk scene için aşık oluşturmak.
				else{
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();

					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/asikust1.obj', function(data){

						for(var i = 0; i < (settings.stepEn / 2.1 / 1.95); i++){	//düzelt.
							
							var selectedItem1 = app.scene.getObjectByName("asik" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("asik1" + i);
							app.scene.remove(selectedItem1);

							var object = loader.parse(data);
							object.position.set(((settings.stepEn / 2) - 0.2) - (1.95 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
							object.rotateY(0);
							object.name = "asik" + i;
							object.scale.set(0.3, 0.5, 3.82);
							app.scene.add(object);
											
							var object = loader.parse(data);
							object.position.set(((settings.stepEn / 2) + 0.35) + (1.95 * i), 2.7 + settings.Yükseklik / 1.15 - (0.35 * i), - (settings.Boy) / 2);
							object.rotateY(0);
							object.name = "asik1" + i;
							object.scale.set(0.3, 0.5, 3.82);
							app.scene.add(object);
 

						}
						},
							function (xhr) {

								//console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
							  //if download fails
							function (xhr) {

							   // console.error('An error happened : ' + xhr);
							}
					);
				}
			}
			//olukları ekleme fonksiyonu
			this.olukEkle = function(){
				
				if(settings.En / settings.stepEn > 1){
					
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
					
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/oluk.obj', function(data){
						
						var selectedItem1 = app.scene.getObjectByName("olukSag1");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("olukSol1");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("olukIlk");
						app.scene.remove(selectedItem1);
						
						var object = loader.parse(data);
						object.position.set(-0.35, 0.85 + settings.Yükseklik / 1.178, - (settings.Boy) / 2);
						object.rotateY(0);
						object.name= "olukIlk";
						object.scale.set(0.2, 0.15, ((settings.Boy) / 98.3284));
						app.scene.add(object);
						
						},
							function(xhr){

							},
							function(xhr){
								//console.error ...	
							}
						);

					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/oluk.obj', function(data){
						
						var selectedItem1 = app.scene.getObjectByName("olukSag1");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("olukSol1");
						app.scene.remove(selectedItem1);
						
						if(settings.En % settings.stepEn === 0){
							
							for(var i = 0; i < (settings.En / settings.stepEn); i++){

								var selectedItem1 = app.scene.getObjectByName("oluk" + i);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(-0.2 + (settings.stepEn * (i + 1)), 0.85 + settings.Yükseklik / 1.178, - (settings.Boy) / 2);
								object.rotateY(0);
								object.name= "oluk" + i;
								object.scale.set(0.2, 0.15, ((settings.Boy) / 98.3284));
								app.scene.add(object);
							}
						}
						
						else{
							
							for(var i = 0; i < (settings.En / settings.stepEn) - 1; i++){

								var selectedItem1 = app.scene.getObjectByName("oluk" + i);
								app.scene.remove(selectedItem1);

								var object = loader.parse(data);
								object.position.set(-0.2 + (settings.stepEn * (i + 1)), 0.85 + settings.Yükseklik / 1.178, - (settings.Boy) / 2);
								object.rotateY(0);
								object.name= "oluk" + i;
								object.scale.set(0.2, 0.15, ((settings.Boy) / 98.3284));
								app.scene.add(object);
							}
						}
						},
							function(xhr){

							},
							function(xhr){
								//console.error ...	
							}
						);
				}
				
				else{
					//başlangıç olukları
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
					
					var selectedItem1 = app.scene.getObjectByName("olukIlk");
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("olukSag1");
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("olukSol1");
					app.scene.remove(selectedItem1);

					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/oluk.obj', function(data){

						var object = loader.parse(data);
						object.position.set(-0.3 + settings.stepEn, 0.7 + settings.Yükseklik / 1.15, - settings.Boy / 2);
						object.rotateY(0);
						object.name= "olukSag1";
						object.scale.set(0.2, 0.15, 0.6102);
						app.scene.add(object);
					},
						function(xhr){

						},
						function(xhr){
								//console.error ...	
						}
					);
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/olukSol.obj', function(data){

						var object = loader.parse(data);
						object.position.set(-0.2, 0.6 + settings.Yükseklik / 1.15, - settings.Boy / 2);
						object.rotateY(0.0);
						object.name= "olukSol1";
						object.scale.set(0.2, 0.15, 0.6102);
						app.scene.add(object);
					},
						function(xhr){

						},
						function(xhr){

						}
					);
				}
			}
			//Vinçsiz orta kolon ekleme
			this.VincsizOrtaKolonEkle = function(){

				var manager = new THREE.LoadingManager();
				var loader = new THREE.OBJLoader(manager);
				var fileloader = new THREE.FileLoader();
				this.makasEkle();
				this.olukEkle();
				this.asikEkle();
				this.VincKirisleriKaldir();
				settings.KolonAltObjEkle();
					
				if(this.AraKatEkle === false){
				//iki for ile x ve y ekseninde çoğalan vinçsiz orta kolonlar oluşturuluyor.
				fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincsizOrtaKolon.obj', function(data){
						
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

							var selectedItem1 = app.scene.getObjectByName("x" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("y" + i);
							app.scene.remove(selectedItem1);
							var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
							app.scene.remove(selectedItem);
							var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
							app.scene.remove(selectedItem1);
							/*var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
							app.scene.remove(selectedItem1);*/
							var selectedItem1 = app.scene.getObjectByName("t" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("k" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("z" + i + j);
							//app.scene.remove(selectedItem1);

							if(settings.En % settings.stepEn === 0){

								for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){

									var selectedItem1 = app.scene.getObjectByName("z" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(2.5 + (settings.stepEn * (j + 1)), 0, 5 - (settings.stepBoy * i));
									object.rotateY(-1.6);
									object.name = "z" + i + j;
									object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
									app.scene.add(object);
								}
							}

							else{

								for(var j = 0; j < ((settings.En / settings.stepEn) - 2); j++){

									var selectedItem1 = app.scene.getObjectByName("z" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(2.5 + (settings.stepEn * (j + 1)), 0, 5 - (settings.stepBoy * i));
									object.rotateY(-1.6);
									object.name = "z" + i + j;
									object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
									app.scene.add(object);
								}
							}
						}
					},
						function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
							  //if download fails
						function(xhr){

							   // console.error('An error happened : ' + xhr);""
						}
					);
					//kenar kolonlar ayrı şekilde oluşturuldu.
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincsizKenarKolon.obj', function(data){

						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

							/*var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
							app.scene.remove(selectedItem1);*/
							
							var object = loader.parse(data);
							object.position.set(2.5 + (settings.En - (settings.En % settings.stepEn)), 0, 5 - (settings.stepBoy * i));
							object.rotateY(-1.6);
							object.name = "VincsizKenarKolonX" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);

							var object = loader.parse(data);
							object.position.set(-2.7, 0, -5 - (settings.stepBoy * i));
							object.rotateY(1.58);
							object.name = "VincsizKenarKolonY" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);
						}
					},
						function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
							  //if download fails
						function(xhr){

							   // console.error('An error happened : ' + xhr);
						}
					);
				}
				//bir holden fazla büyüdüğü zaman ve arakat eklendiği durumda kolonları 
				else{
					
					settings.AraKatKolonlariEkle();
				}
			}
			//Vinçli orta kolon ekleme
			this.VincliOrtaKolonEkle = function(){
				
				var manager = new THREE.LoadingManager();
				var loader = new THREE.OBJLoader(manager);
				var fileloader = new THREE.FileLoader();
				this.makasEkle();
				this.olukEkle();
				this.asikEkle();
				settings.KolonAltObjEkle();
					
				if(this.AraKatEkle === false){
				//iki for ile x ve y ekseninde çoğalan vinçsiz orta kolonlar oluşturuluyor.
				fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincliKenarKolonlar/VincliOrtaKolon14.obj', function(data){
//*****************************************hooop******************************************************************
						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

							var selectedItem1 = app.scene.getObjectByName("x" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("y" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("z" + i + j);
							//app.scene.remove(selectedItem1);

							if(settings.En % settings.stepEn === 0){

								for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){

									var selectedItem1 = app.scene.getObjectByName("z" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(2.5 + (settings.stepEn * (j + 1)), 0, 5 - (settings.stepBoy * i));
									object.rotateY(-1.6);
									object.name = "z" + i + j;
									object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
									app.scene.add(object);
								}
							}

							else{

								for(var j = 0; j < ((settings.En / settings.stepEn) - 2); j++){

									var selectedItem1 = app.scene.getObjectByName("z" + i + j);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(2.5 + (settings.stepEn * (j + 1)), 0, 5 - (settings.stepBoy * i));
									object.rotateY(-1.6);
									object.name = "z" + i + j;
									object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
									app.scene.add(object);
								}
							}
						}
					},
						function(xhr){

							//console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
							  //if download fails
						function(xhr){

							// console.error('An error happened : ' + xhr);
						}
					);
					//kenar kolonlar ayrı şekilde oluşturuldu.
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/VincliKenarKolon14.obj', function(data){

						for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

							/*var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
							app.scene.remove(selectedItem1);*/
							
							var object = loader.parse(data);
							object.position.set(2.7 + (settings.En - (settings.En % settings.stepEn)), 0, 5 - (settings.stepBoy * i));
							object.rotateY(-1.6);
							object.name = "VincliKenarKolonEkleX" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);

							var object = loader.parse(data);
							object.position.set(-2.9, 0, -5 - (settings.stepBoy * i));
							object.rotateY(1.58);
							object.name = "VincliKenarKolonEkleY" + i;
							object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
							app.scene.add(object);

						}
					},
						function(xhr){

							// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
						},
							  //if download fails
						function(xhr){

						// console.error('An error happened : ' + xhr);
						}
					);
				}
				
				else{
					
					settings.AraKatKolonlariEkle();
				}
			}
			//Vinç Kirişleri ekleme
			this.VincKirisiEkle = function(){
				
				if(this.VincliKolonlar === true){
			
					if(settings.En / settings.stepEn > 1){

						var manager = new THREE.LoadingManager();
						var loader = new THREE.OBJLoader(manager);
						var fileloader = new THREE.FileLoader();

						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/vincKirisiSon.obj', function(data){

							var selectedItem1 = app.scene.getObjectByName("vincKirisiSol");
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("vincKirisiSag");
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("vincKirisiSon");
							app.scene.remove(selectedItem1);
							
							//ilk kiriş position'ı farklı olduğu için ayrı şekilde üretildi
							var object = loader.parse(data);
							object.position.set(1, settings.Yükseklik / 1.65, (-(settings.Boy) + 0) / 2);
							object.rotateY(0);
							object.name= "vincKirisiIlk";
							object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
							app.scene.add(object);
							
							var object = loader.parse(data);
							object.position.set(((settings.En / settings.stepEn) * settings.stepEn) - (settings.En % settings.stepEn) - 1.2, settings.Yükseklik / 1.65, (-(settings.Boy) + 0.5) / 2);
							object.rotateY(0);
							object.name= "vincKirisiSon";
							object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
							app.scene.add(object);
							
							//geri kalan kirişler dinamik olarak eklendi ekrana
							
							if(settings.En % settings.stepEn === 0){
								
								for(var i = 1; i < (settings.En / settings.stepEn); i++){

									var selectedItem1 = app.scene.getObjectByName("vincKiris" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("vincKiris1" + i);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(1 + (settings.stepEn * i), settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
									object.rotateY(0);
									object.name = "vincKiris" + i;
									object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
									app.scene.add(object);

									var object = loader.parse(data);
									object.position.set(-1.2 +(settings.stepEn * i), settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
									object.rotateY(0);
									object.name= "vincKiris1" + i;
									object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
									app.scene.add(object);
								}
							}
							
							else{
								
								for(var i = 1; i < (settings.En / settings.stepEn) - 1; i++){

									var selectedItem1 = app.scene.getObjectByName("vincKiris" + i);
									app.scene.remove(selectedItem1);
									var selectedItem1 = app.scene.getObjectByName("vincKiris1" + i);
									app.scene.remove(selectedItem1);

									var object = loader.parse(data);
									object.position.set(1 + (settings.stepEn * i), settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
									object.rotateY(0);
									object.name= "vincKiris" + i;
									object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
									app.scene.add(object);
									
									var object = loader.parse(data);
									object.position.set(- 1.2 +(settings.stepEn * i), settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
									object.rotateY(0);
									object.name= "vincKiris1" + i;
									object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
									app.scene.add(object);
								}
							}
						},	
							function(xhr){
								
							},
							function(xhr){
									//console.error ...	
							}
						);
					}	
						
					else{
						
						//console.log("vinç kirişi yükseklik değeri" + settings.Yükseklik);
							
						var manager = new THREE.LoadingManager();
						var loader = new THREE.OBJLoader(manager);
						var fileloader = new THREE.FileLoader();
						var selectedItem1 = app.scene.getObjectByName("vincKirisiIlk");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKirisiSon");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKirisiSol");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKirisiSag");
						app.scene.remove(selectedItem1);
						
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/vincKirisiSon.obj', function(data){
							
							var object = loader.parse(data);
							object.position.set(-1.2 + settings.stepEn, settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
							object.rotateY(0);
							object.name= "vincKirisiSol";
							object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
							app.scene.add(object);
						},
							function(xhr){

							},					
							function(xhr){
								//console.error ...	
							}
						);
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/vincKirisiSon.obj', function(data){

							var object = loader.parse(data);
							object.position.set(1, settings.Yükseklik / 1.6, (-(settings.Boy) + 0.5) / 2);
							object.rotateY(0.0);
							object.name= "vincKirisiSag";
							object.scale.set(0.45, 0.6, ((settings.Boy) / 39.2168));
							app.scene.add(object);
						},
							function(xhr){

							},
							function(xhr){

							}
						);
					}	
				}
				else{
					
					settings.Vinc_Kirisleri_Ekle = false;
					
					alert("Vinçli kolonlar aktif değilken vinç kirişleri açılamaz, Vinçli Kolonlar seçeneğini seçtikten sonra tekrar deneyiniz.");
					
					settings.VincKirisleriKaldir();
				}
			}
			//Vinç Kirişlerini kaldırma işlemi
			this.VincKirisleriKaldir = function(){
				
				var selectedItem1 = app.scene.getObjectByName("vincKirisiIlk");
				app.scene.remove(selectedItem1);
				var selectedItem1 = app.scene.getObjectByName("vincKirisiSon");
				app.scene.remove(selectedItem1);
				
				if (settings.En / settings.stepEn > 1){
					
					for(var i = 1; i < settings.En / settings.stepEn + 1; i++){
							
						var selectedItem1 = app.scene.getObjectByName("vincKiris" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKiris1" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKirisiIlk");
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("vincKirisiSon");
						app.scene.remove(selectedItem1);
					}
				}
				
				else{
					
					settings.Vinc_Kirisleri_Ekle = false;
					var selectedItemVKS = app.scene.getObjectByName("vincKirisiSol");
					app.scene.remove(selectedItemVKS);
					var selectedItemVKS = app.scene.getObjectByName("vincKirisiSag");
					app.scene.remove(selectedItemVKS);
					var selectedItem1 = app.scene.getObjectByName("vincKirisiIlk");
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("vincKirisiSon");
					app.scene.remove(selectedItem1);
				}
			}
			//Rüzgar Kolonları ekleme
			this.RuzgarKolonlariEkle = function(){
							
				//***rüzgar kolonlarını ekleme koşulları
				if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
							
					//rüzgar kolonlarının alt standlarını oluşturma.
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
							
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){
												
						for(var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 3)) - 1; i++){
							
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltÖn" + i);
							app.scene.remove(selectedItem);
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltArka" + i);
							app.scene.remove(selectedItem);
							                                        
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, 0, - 2.1);
							object.name = "RuzgarKolonAltÖn" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){
									
								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, 0, - 1.95 - settings.Boy);
							object.name = "RuzgarKolonAltArka" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
						}
                    },
                        function(xhr){
 
                          //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function(xhr){
                        
                           //console.error('An error happened : ' + xhr);
                        }
                    );
					
					//***rüzgar kolonlarını oluşturma ve ekleme.
					for (var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 3)) - 1; i++){
						
						var selectedItem1 = app.scene.getObjectByName("araKatÖn" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("araKatArka" + i);
						app.scene.remove(selectedItem1);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, (settings.Yükseklik / 2.25) , 0);
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatÖn" + i;
						object.receiveShadow = true;
						app.scene.add(object);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, (settings.Yükseklik / 2.25), - settings.Boy);
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatArka" + i;
						object.receiveShadow = true;
						app.scene.add(object);
					}
				}
				
				else{
					
					//rüzgar kolonlarının alt standlarını oluşturma.
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();
							
					fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){
												
						for(var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)) - 1; i++){
							
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltÖn" + i);
							app.scene.remove(selectedItem);
							var selectedItem = app.scene.getObjectByName("RuzgarKolonAltArka" + i);
							app.scene.remove(selectedItem);
							                                        
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, 0, - 2.1);
							object.name = "RuzgarKolonAltÖn" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){
									
								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
							var object = loader.parse(data);
							object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, 0, - 1.95 - (settings.Boy));
							object.name = "RuzgarKolonAltArka" + i;
							object.scale.set(0.21, 0.21, 0.21);
							object.traverse(function (child){

								if(child instanceof THREE.Mesh)
									child.material.color.setHex(0x969696);
							});
							app.scene.add(object);
							
						}
                    },
                        function(xhr){
 
                          //console.log((xhr.loaded / xhr.total * 100) + '% loaded');
                        },
                          //if download fails
                        function(xhr){
                        
                           //console.error('An error happened : ' + xhr);
                        }
                    );
					
					//***rüzgar kolonlarını oluşturma ve ekleme.
					for (var i = 0; i <= ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)) - 1; i++){
						
						var selectedItem1 = app.scene.getObjectByName("araKatÖn" + i);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("araKatArka" + i);
						app.scene.remove(selectedItem1);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 2.25) , 0);
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatÖn" + i;
						object.receiveShadow = true;
						app.scene.add(object);
						
						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({ color: 0xffffff }));
						object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 2.25), - (settings.Boy));
						object.scale.set(0.2, settings.Yükseklik / 5.65, 0.2);
						object.children.color = 0xff0000;
						object.castShadow = true;
						object.name = "araKatArka" + i;
						object.receiveShadow = true;
						app.scene.add(object);
					}
				}
			}
			//ekrandaki bütün objeleri kaldırma fonksiyonu
			this.EkranResetleme = function(){
				
				for(var i = app.scene.children.length - 1; i >= 0; i--){
					
					var obj = app.scene.children[i];
					app.scene.remove(obj);
				}
			}
			//ara kat ekleme 
			this.AraKatEkleme = function(){

				if(this.VincliKolonlar === false){
					
					settings.VincsizKolonEkle();
				}
				
				else{
					
					settings.kolEkle();
				}
				
				if(settings.En % settings.stepEn === 0){
					
					for(var i =  0; i < (settings.En / settings.stepEn); i++){

						var selectedItem1 = app.scene.getObjectByName("araKat" + i);
						app.scene.remove(selectedItem1);
						var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
						app.scene.remove(selectedItem);
						var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
						app.scene.remove(selectedItem1);

						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
						object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (i + 1)), settings.Yükseklik / 2.25, - (settings.Boy) / 2);
						object.scale.set( - 0.1 + settings.stepEn / 5.2, 0.1, (settings.Boy) / 5);
						object.name = "araKat" + i;
						app.scene.add(object);
					}
					//arakat destek kolonları ekleme.
					if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){

						for(var i = 0; i < ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 3)); i++){

							for(var j = 0; j < ((settings.Boy) / settings.stepBoy) ; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "araKatDestek" + i + j;
								app.scene.add(object);
							}
						}
					}
					else{
						
						for(var i = 0; i < ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)); i++){

							for(var j = 0; j < ((settings.Boy) / settings.stepBoy) ; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "araKatDestek" + i + j;
								app.scene.add(object);
							}
						}
						//boş dursun.
					}
				}
				
				else{
					
					for(var i =  0; i < (settings.En / settings.stepEn) - 1; i++){

						var selectedItem1 = app.scene.getObjectByName("araKat" + i);
						app.scene.remove(selectedItem1);
						var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
						app.scene.remove(selectedItem);
						var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
						app.scene.remove(selectedItem1);

						var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
						object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (i + 1)), settings.Yükseklik / 2.25, - (settings.Boy) / 2);
						object.scale.set( - 0.1 + settings.stepEn / 5.2, 0.1, (settings.Boy) / 5);
						object.name = "araKat" + i;
						app.scene.add(object);
					}
					//arakat destek kolonları ekleme.
					if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){

						for(var i = 0; i < ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 3)); i++){

							for(var j = 0; j < ((settings.Boy) / settings.stepBoy) ; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "araKatDestek" + i + j;
								app.scene.add(object);
							}
						}
					}
					
					else{
						
						for(var i = 0; i < ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 2)); i++){

							for(var j = 0; j < ((settings.Boy) / settings.stepBoy) ; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "araKatDestek" + i + j;
								app.scene.add(object);
							}
						}
					}
				}
			}
			//ara katı tutan kolonların eklenmesi
			this.AraKatKolonlariEkle = function(){
								
					var manager = new THREE.LoadingManager();
					var loader = new THREE.OBJLoader(manager);
					var fileloader = new THREE.FileLoader();

					if(this.VincliKolonlar === false){

						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincsizOrtaKolonSon.obj', function(data){

							for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){

								var selectedItem1 = app.scene.getObjectByName("x" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("y" + i);
								app.scene.remove(selectedItem1);
								var selectedItem = app.scene.getObjectByName("VincliKenarKolonEkleX" + i);
								app.scene.remove(selectedItem);
								var selectedItem1 = app.scene.getObjectByName("VincliKenarKolonEkleY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("VincsizKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("z" + i + j);
								app.scene.remove(selectedItem1);

								if(settings.En % settings.stepEn === 0){

									for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){

										var selectedItem1 = app.scene.getObjectByName("z" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "z" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}

								else{

									for(var j = 0; j < ((settings.En / settings.stepEn) - 2); j++){

										var selectedItem1 = app.scene.getObjectByName("z" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "z" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
						//kenar kolonlar ayrı şekilde oluşturuldu.
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatKenarKolonSon.obj', function(data){

							var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
							app.scene.remove(selectedItem1);

							for(var i = 0; i < (settings.Boy / settings.stepBoy) + 1; i++){

								var object = loader.parse(data);
								object.position.set(0 + (settings.En - (settings.En % settings.stepEn)), 0, 0.34 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "AraKatKenarKolonX" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, -0.45 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "AraKatKenarKolonY" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
					}

					else{

						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincliOrtaKolonSon.obj', function(data){

							for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){

								var selectedItem1 = app.scene.getObjectByName("x" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("y" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonX" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonY" + i);
								app.scene.remove(selectedItem1);
								var selectedItem1 = app.scene.getObjectByName("z" + i + j);
								app.scene.remove(selectedItem1);

								if(settings.En % settings.stepEn === 0){

									for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){

										var selectedItem1 = app.scene.getObjectByName("z" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "z" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}

								else{

									for(var j = 0; j < ((settings.En / settings.stepEn) - 2); j++){

										var selectedItem1 = app.scene.getObjectByName("z" + i + j);
										app.scene.remove(selectedItem1);

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "z" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
						//kenar kolonlar ayrı şekilde oluşturuldu.
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincliKenarKolon.obj', function(data){

							var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonX" + i);
							app.scene.remove(selectedItem1);
							var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonY" + i);
							app.scene.remove(selectedItem1);

							for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){

								var object = loader.parse(data);
								object.position.set(0 + (settings.En - (settings.En % settings.stepEn)), 0, 0.34 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "ArakatVincliKenarKolonX" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, -0.45 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "ArakatVincliKenarKolonY" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
					}				
			}
			//ara kat ve kolonları kaldırılması
			this.AraKatKaldir = function(){
				
				for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){
					
					var selectedItem1 = app.scene.getObjectByName("x" + i);
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("y" + i);
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonX" + i);
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("ArakatVincliKenarKolonY" + i);
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonX" + i);
					app.scene.remove(selectedItem1);
					var selectedItem1 = app.scene.getObjectByName("AraKatKenarKolonY" + i);
					app.scene.remove(selectedItem1);
					
					for(var j = 0; j < ((settings.En / settings.stepEn) - 1); j++){
						
						var selectedItem1 = app.scene.getObjectByName("z" + i + j);
						app.scene.remove(selectedItem1);
					}
				}
				
				for(var t= 0; t<2; t++){
					
					for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){

						for(var j = 0; j < ((settings.En / (settings.stepEn / 3)) + 2); j++){

							var selectedItem1 = app.scene.getObjectByName("kolonAltlikAraKat" + i + j);
							app.scene.remove(selectedItem1);
						}
					}
				}
				
				for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){
								
					for(var j = 0; j < ((settings.En / (settings.stepEn / 2)) + 2); j++){

						var selectedItem1 = app.scene.getObjectByName("kolonAltlikAraKat" + i + j);
						app.scene.remove(selectedItem1);
					}
				}
				
				
				for(var i =  0; i < (settings.En / settings.stepEn); i++){
				
					var selectedItem1 = app.scene.getObjectByName("araKat" + i);
					app.scene.remove(selectedItem1);
				}
				
				for(var i = 0; i < ((settings.En - (settings.En % settings.stepEn)) / (settings.stepEn / 3)) + 1; i++){

					for(var j = 0; j < ((settings.Boy) / settings.stepBoy) ; j++){
							
						var selectedItem1 = app.scene.getObjectByName("araKatDestek" + i + j);
						app.scene.remove(selectedItem1);
					}
				}
				
				//destek kolon altlık kaldır
				
				for(var i = 0; i < ((settings.Boy) / settings.stepBoy) + 1; i++){
													
					for(var j = 0; j < ((settings.En / (settings.stepEn / 3)) + 4); j++){
						
						var selectedItem1 = app.scene.getObjectByName("kolonAltlikAraKat" + i + j);
						app.scene.remove(selectedItem1);
					}
				}
				//başlangıç arakat destek kolonları standlarını silme
				for(var i = 0; i < settings.Boy / settings.stepBoy; i++){
					
					var selectedItem1 = app.scene.getObjectByName("kolonAltlikOrta" + i);
					app.scene.remove(selectedItem1);
				}
			}

			this.kismiAraKatKolonlariEkle = function(){
				
				//kısmı arakat eklenmek istenildiğinde kolonları bu şekilde ekle.					
				var manager = new THREE.LoadingManager();
				var loader = new THREE.OBJLoader(manager);
				var fileloader = new THREE.FileLoader();

				if(this.VincliKolonlar === false){

						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincsizOrtaKolonSon.obj', function(data){
							
							for(var i = 0; i < settings.araKatUzunlugu + 1; i++){
								
								if(settings.En % settings.stepEn === 0){

									for(var j = 0; j < settings.araKatGenisligi - 1; j++){

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "hoho" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}

								else{

									for(var j = 0; j < settings.araKatGenisligi - 1; j++){

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "hoho" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
						//kenar kolonlar ayrı şekilde oluşturuldu.
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatKenarKolonSon.obj', function(data){

							for(var i = 0; i < settings.araKatUzunlugu + 1; i++){

								var object = loader.parse(data);
								object.position.set(0 + (settings.En - (settings.En % settings.stepEn)), 0, 0.34 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "x" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								//app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, -0.45 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "hoho2" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
					}
					
				else{

						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincliOrtaKolonSon.obj', function(data){

							for(var i = 0; i < settings.araKatUzunlugu + 1; i++){

								if(settings.En % settings.stepEn === 0){

									for(var j = 0; j < (settings.araKatGenisligi - 1); j++){

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "hoho" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}

								else{

									for(var j = 0; j < (settings.araKatGenisligi - 1); j++){

										var object = loader.parse(data);
										object.position.set(3.6 + (settings.stepEn * (j + 1)), 0, 0.16 - (settings.stepBoy * i));
										object.rotateY(-1.6);
										object.name = "hoho" + i + j;
										object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
										app.scene.add(object);
									}
								}
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
						//kenar kolonlar ayrı şekilde oluşturuldu.
						fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/AraKatVincliKenarKolon.obj', function(data){

							for(var i = 0; i < settings.araKatUzunlugu + 1; i++){

								var object = loader.parse(data);
								object.position.set(0 + (settings.En - (settings.En % settings.stepEn)), 0, 0.34 - (settings.stepBoy * i));
								object.rotateY(-1.6);
								object.name = "x" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								//app.scene.add(object);

								var object = loader.parse(data);
								object.position.set(0, 0, -0.45 - (settings.stepBoy * i));
								object.rotateY(1.58);
								object.name = "hoho2" + i;
								object.scale.set(0.2, settings.Yükseklik / 65, 0.2);
								app.scene.add(object);
							}
						},
							function(xhr){

								// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
							},
								  //if download fails
							function(xhr){

								   // console.error('An error happened : ' + xhr);
							}
						);
					}
			}
			
			this.objeSayisiniBul = function () {
				debugger;
				if(settings.En / settings.stepEn > 1){
					
					//tali kiriş bulma
					//kompleAraKat varsa -->
					if(settings.AraKatEkle == true){
						//stepEn 3 e bölündüğü durum
						if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){

							//rüzgar kolon sayısı + arakat kolon sayısı
							ruzgarKolonSayisi = 0;
							
							arakatKolon = (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2) * (((settings.Boy) / settings.stepBoy) + 1);
							//rüzgar kolon sayısı + arakat kolon sayısı
							
							if((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 3) < settings.stepBoy){
								
								taliKiris = (((settings.En -  (settings.En % settings.stepEn)) / settings.stepEn) * 3) * (((settings.Boy ) / settings.stepBoy) + 1);
								
								arakatKiris = ((settings.Boy) / settings.stepBoy) * ((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3) + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil(settings.stepBoy / 2.35);
								
								ttPlak = (araSayiTtPlak * ((settings.Boy) / settings.stepBoy)) * (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3);
							}
							else{
								
								taliKiris = ((settings.Boy ) / settings.stepBoy) * ((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3) + 1);
								
								arakatKiris = (((settings.En -  (settings.En % settings.stepEn)) / settings.stepEn) * 3) * (((settings.Boy) / settings.stepBoy) + 1);
								
								//ttplak bulma
								var araSayiTtPlak = Math.ceil((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 3) / 2.35);
								
								ttPlak = ((araSayiTtPlak * 3) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * ((settings.Boy) / settings.stepBoy);
							}
						}
						//stepEn 2ye bölündüğü durum
						else{
							
							//rüzgar kolon sayısı + arakat kolon sayısı
							ruzgarKolonSayisi = 0;
							
							arakatKolon = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * (((settings.Boy) / settings.stepBoy) + 1);
							//rüzgar kolon sayısı + arakat kolon sayısı
							
							//a-a1 arası stepBoydan küçük
							if((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 2) < settings.stepBoy){
								
								taliKiris = (((settings.En -  (settings.En % settings.stepEn)) / settings.stepEn) * 2) * (((settings.Boy ) / settings.stepBoy) + 1);
								
								arakatKiris = ((settings.Boy) / settings.stepBoy) * ((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2) + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil(settings.stepBoy / 2.35);
								
								ttPlak = (araSayiTtPlak * ((settings.Boy) / settings.stepBoy)) * (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3);
							}
							else{
								
								taliKiris = ((settings.Boy) / settings.stepBoy) * ((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2) + 1);
								
								arakatKiris = (((settings.En -  (settings.En % settings.stepEn)) / settings.stepEn) * 2) * (((settings.Boy) / settings.stepBoy) + 1);
								
								//ttplak bulma
								var araSayiTtPlak = Math.ceil((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 2) / 2.35);
								
								ttPlak = ((araSayiTtPlak * 2) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * ((settings.Boy) / settings.stepBoy);
							}
						}
					}
					
					if(settings.KismiAraKatEkle == true){
						
						if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
							
							//rüzgarkolonları ve arakatkolonlarını bulma
							
							arakatKolon = ((settings.araKatGenisligi * 2) * (settings.araKatUzunlugu + 1));
							
							//rüzgarkolonunu kısmi arakat varken hesaplamada arakat kolonu olan rüzgar kolonlarını hesaba kat.
							if(((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) == settings.araKatGenisligi){
								
								if(((settings.Boy) / settings.stepBoy) == settings.araKatUzunlugu){
									
									ruzgarKolonSayisi = 0;
								}
								else{
									
									ruzgarKolonSayisi = (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2).toFixed(0);
								}
							}
							else{
								
								if(((settings.Boy) / settings.stepBoy) == settings.araKatUzunlugu){
									
									var araSayiRuzgarKolon = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) - settings.araKatGenisligi;
									
									ruzgarKolonSayisi = (araSayiRuzgarKolon * 4).toFixed(0);
								}
								else{
									
									var araSayiRuzgarKolon = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) - settings.araKatGenisligi;
									
									ruzgarKolonSayisi = ((araSayiRuzgarKolon * 4) + (settings.araKatGenisligi * 2)).toFixed(0);
								}
							}
							
							//rüzgarkolonları ve arakatkolonlarını bulma son*
							
							//talikiris arakatkiris ttplak sayısı bulma
							if((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 3) < settings.stepBoy){
								
								taliKiris = (settings.araKatGenisligi * 3) * (settings.araKatUzunlugu + 1);
								
								arakatKiris = (settings.araKatUzunlugu) * ((settings.araKatGenisligi * 3) + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil(settings.stepBoy / 2.35);
								
								ttPlak = (araSayiTtPlak * settings.araKatUzunlugu) * (settings.araKatGenisligi * 3);
							}
							else{
								
								taliKiris = (settings.araKatUzunlugu) * ((settings.araKatGenisligi * 3) + 1);
								
								arakatKiris = (settings.araKatGenisligi * 3) * (settings.araKatUzunlugu + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 3) / 2.35);
								
								//console.log("heloooooooooooooooooooooo" + araSayiTtPlak);
								
								ttPlak = (araSayiTtPlak * 3) * (settings.araKatGenisligi) * (settings.araKatUzunlugu);
							}
						}
						
						else{
							
							//rüzgarkolonları ve arakatkolonları bulma hol 2ye bölündüğünde
							
							arakatKolon = ((settings.araKatGenisligi) * (settings.araKatUzunlugu + 1));
							
							//rüzgarkolonunu kısmi arakat varken hesaplamada arakat kolonu olan rüzgar kolonlarını hesaba kat.
							if(((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) == settings.araKatGenisligi){
								
								if(((settings.Boy) / settings.stepBoy) == settings.araKatUzunlugu){
									
									ruzgarKolonSayisi = 0;
								}
								else{
									
									ruzgarKolonSayisi = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn).toFixed(0);
								}
							}
							else{
								
								if(((settings.Boy) / settings.stepBoy) == settings.araKatUzunlugu){
									
									var araSayiRuzgarKolon = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) - settings.araKatGenisligi;
									
									ruzgarKolonSayisi = (araSayiRuzgarKolon * 2).toFixed(0);
								}
								else{
									
									var araSayiRuzgarKolon = ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) - settings.araKatGenisligi;
									
									ruzgarKolonSayisi = ((araSayiRuzgarKolon * 2) + (settings.araKatGenisligi)).toFixed(0);
								}
							}
							
							//rüzgarkolonları ve arakatkolonları bulma son*
							
							if((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 2) < settings.stepBoy){
								
								taliKiris = (settings.araKatGenisligi * 2) * (settings.araKatUzunlugu + 1);
								
								arakatKiris = (settings.araKatUzunlugu) * ((settings.araKatGenisligi * 2) + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil(settings.stepBoy / 2.35);
								
								ttPlak = (araSayiTtPlak * settings.araKatUzunlugu) * (settings.araKatGenisligi * 2);
							}
							else{
								
								taliKiris = (settings.araKatUzunlugu) * ((settings.araKatGenisligi * 2) + 1);
								
								arakatKiris = (settings.araKatGenisligi * 2) * (settings.araKatUzunlugu + 1);
								
								//ttPlak bulma
								var araSayiTtPlak = Math.ceil((((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) / 2) / 2.35);
								
								ttPlak = (araSayiTtPlak * 2) * (settings.araKatGenisligi) * (settings.araKatUzunlugu);
							}
						}
					}
					
					if(settings.AraKatEkle == false && settings.KismiAraKatEkle == false){
						
						//ara kat yoksa ve 3e bölünüyorsa stepEn
						if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
							
							//rüzgar kolon sayısı + arakat kolon sayısı
							ruzgarKolonSayisi = (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 4).toFixed(0);
							
							arakatKolon = 0;
							//rüzgar kolon sayısı + arakat kolon sayısı
						}
						else{
							
							ruzgarKolonSayisi = (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2).toFixed(0);
							
							arakatKolon = 0;
						}
					}

					
					//tali kiriş bulma
					
					//vinç konsol yerleri
					if(settings.VincliKolonlar === true){
						
						if(settings.En > 0 && settings.En <30){
							
							vincKirisYeriEn = 'A-B';
							//vincKirisYeriBoy = '0-7';
						}
						else if(settings.En >= 30 && settings.En <60){
							
							vincKirisYeriEn = 'A-C';
							//vincKirisYeriBoy = '0-7';
						}
						else if(settings.En >=60 && settings.En <90){
							
							vincKirisYeriEn = 'A-D';
						}
						else if(settings.En >=90 && settings.En <=100){
							
							vincKirisYeriEn = 'A-E';
						}
						
						var vincKirisYeriBoyIkinciDegisken = ((settings.Boy) / settings.stepBoy) + 1;
						vincKirisYeriBoy = '1-' + vincKirisYeriBoyIkinciDegisken;
						//vincKirisYeriEn = 'A-B';
						//vincKirisYeriBoy = '0-7';
					}
					//vinç konsol yerleri
					
					
					//**ara kat yerleri bulma
					if(settings.AraKatEkle ==  true){
					   
						if(settings.En > 0 && settings.En <30){
							
							araKatYeriEn = 'A-B';
						}
						else if(settings.En >= 30 && settings.En <60){
							
							araKatYeriEn = 'A-C';
						}
						else if(settings.En >=60 && settings.En <90){
							
							araKatYeriEn = 'A-D';
						}
						else if(settings.En >=90 && settings.En <=100){
							
							araKatYeriEn = 'A-E';
						}
						
						var araKatYeriBoyIkinciDegisken = ((settings.Boy) / settings.stepBoy) + 1;
						araKatYeriBoy = '1-' + araKatYeriBoyIkinciDegisken;
						//var araKatYeriEn = 'A-B';
						//var araKatYeriBoy ='0-7';
					}
					
					if(settings.KismiAraKatEkle == true){
						
						if(settings.araKatGenisligi == 1){
							
							araKatYeriEn = 'A-B';	
						}
						else if(settings.araKatGenisligi == 2){
							
							araKatYeriEn = 'A-C';
						}
						else if(settings.araKatGenisligi == 3){
							
							araKatYeriEn = 'A-D';
						}
						else if(settings.araKatGenisligi == 4){
							
							araKatYeriEn = 'A-E';
						}

						var araKatYeriBoyIkinciDegisken = settings.araKatUzunlugu + 1;
						araKatYeriBoy = '1-' + araKatYeriBoyIkinciDegisken;
						
					}
					//**ara kat yerleri bulma
					
					
					//kolon sayısı*
					kolonSayisi = Math.round((((settings.Boy) / settings.stepBoy) + 1) * (((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) + 1));
					
					//console.log("Kolon Sayısı: " + kolonSayisi);
					//
					
					//rüzgar kolonu sayısı + stand sayısı*
					if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){//her holde iki rüzgar kolonu var
					
						if((settings.En < 30 && settings.En > 24) || (settings.En < 90 && settings.En > 82) || (settings.En < 60 && settings.En > 49)){
							
							//ruzgarKolonSayisi = Math.round(((settings.En / settings.stepEn) * 4) - 1);
							//console.log("Rüzgar Kolon Sayısı: " + ruzgarKolonSayisi);
							
							if(settings.AraKatEkle === false){
								
								//tumStandSayisi = Math.round(kolonSayisi + ruzgarKolonSayisi)
								
								//console.log("Tüm stand sayısı: " + tumStandSayisi);
							}
							else{
								
								tumStandSayisi = Math.round(((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3) + 1) * (((settings.Boy) / settings.stepBoy) + 1));

								//console.log("Tüm stand sayısı: " + tumStandSayisi);
							}
						}
						
						else{
							
							//ruzgarKolonSayisi = Math.round(((settings.En / settings.stepEn) * 4));
							//console.log("Rüzgar Kolon Sayısı: " + ruzgarKolonSayisi);
							
							if(settings.AraKatEkle === false){
								
								//console.log("Tüm stand sayısı: " + Math.round(kolonSayisi + ruzgarKolonSayisi));
							}
							
							else{
								
								tumStandSayisi = Math.round(((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 3) + 1) * (((settings.Boy) / settings.stepBoy) + 1));

								//console.log("Tüm stand sayısı: " + tumStandSayisi);
							}
						}
					}
									
					else{
									
						/*ruzgarKolonSayisi = Math.round((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2));
						console.log("Rüzgar Kolon Sayısı: " + ruzgarKolonSayisi);*/
						
						if(settings.AraKatEkle === false){
								
								//console.log("Tüm stand sayısı: " + Math.round(kolonSayisi + ruzgarKolonSayisi));
							}
							
							else{
								
								tumStandSayisi = Math.round(((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) * 2) + 1) * (((settings.Boy) / settings.stepBoy) + 1));

								//console.log("Tüm stand sayısı: " + tumStandSayisi);
							}
						
					}
					//rüzgar kolon sayısı + stand sayısı end*
					
					//oluk sayısı
					olukSayisi = (Math.round((settings.En /  settings.stepEn) + 1) * ((settings.Boy) / settings.stepBoy));
					//console.log("Oluk Sayısı: " + olukSayisi);
					//oluk sayısı end*
					
					//makas sayısı
					makasSayisi = Math.round((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * (((settings.Boy) / settings.stepBoy) + 1));
					//console.log("Makas Sayısı: " + makasSayisi);
					//makas sayısı end*
					
					
					
					//vinç kirişleri sayısı
					if(settings.Vinc_Kirisleri_Ekle === true){
						
						vincKirisiSayisi = Math.round((((((settings.En - (settings.En % settings.stepEn)) / settings.stepEn) - 1) * 2) + 2) * ((settings.Boy) / settings.stepBoy));
						//console.log("Vinç Kirişi Sayısı: " + vincKirisiSayisi);
					}
					
					else{
						
						//console.log("Vinç Kirişi Sayısı: " + 0);
					}
					//vinç kirişleri sayısı end*
					
					//ara kat boyutları
					if(settings.AraKatEkle === false){
						
						//console.log("Komple Ara Kat: " + settings.araKatSayisi);
					}
					
					else{
						
						KompleAraKatHolSayisi = Math.round((settings.En - (settings.En % settings.stepEn)) / settings.stepEn);
						
						KompleAraKatHolBoyutu = (Math.round(((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) * 100) / 100) + "x" + settings.Boy;
						
						//console.log("Komple Ara Kat: " + "Var, " + KompleAraKatHolSayisi + " Adet Hol Sayısı, " + "Her Hol: " + KompleAraKatHolBoyutu + " Boyutlarında.");
					}
					//ara kat boyutları end*
					
					//Kısmi ara kat boyutları
					if((settings.KismiAraKatEkle === false) || (settings.kismiAraKatKaldir === true)){
						
						//console.log("Kısmi Ara Kat: " + settings.KismiaraKatSayisi);
					}
					/*this.araKatUzunlugu = 1,
					this.araKatGenisligi = 1,*/
					if(settings.KismiAraKatEkle === true){
						
						kismiAraKatHolSayisi = settings.araKatGenisligi;
						
						kismiAraKatAksSayisi = settings.araKatUzunlugu;
						
						kismiAraKatHolBoyutu = (settings.araKatGenisligi * (Math.round(((settings.En  + (settings.En % settings.stepEn)) / (settings.En / settings.stepEn)) * 100) / 100));
						
						kismiAraKatAksBoyutu = (Math.round((settings.araKatUzunlugu * settings.stepBoy) *100) / 100);
						
						//console.log("Kısmı Ara Kat: " + " Var, HolxAks: " + settings.araKatGenisligi + "x" + settings.araKatUzunlugu + " Boyutları: " + kismiAraKatHolBoyutu + "x" + kismiAraKatAksBoyutu);
					}
					//kısmi ara kat boyutları end*
					
					//aşık sayısı
					
					if(settings.En > 0 && settings.En < 30){
						
						asikSayisi = ((Math.round((settings.stepEn / 2 / 1.95) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * 2) + 2) * Math.round((settings.Boy) / settings.stepBoy);
						
						//console.log("aşık Sayısı: " + asikSayisi);
					}
					
					else if(settings.En >= 30 && settings.En < 60){
						
						asikSayisi = ((Math.round((settings.stepEn / 2 / 1.95) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * 2) + 4) * Math.round((settings.Boy) / settings.stepBoy);
						
						//console.log("aşık Sayısı: " + asikSayisi);
					}
					
					else if(settings.En >= 60 && settings.En < 90){
							
						asikSayisi = ((Math.round((settings.stepEn / 2 / 1.95) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * 2) + 6) * Math.round((settings.Boy) / settings.stepBoy);
						
						//console.log("aşık Sayısı: " + asikSayisi);
					}
					
					else{
						
						asikSayisi = ((Math.round((settings.stepEn / 2 / 1.95) * ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) * 2) + 8) * Math.round((settings.Boy) / settings.stepBoy);

						//console.log("aşık Sayısı: " + asikSayisi);
					}
					
					//aşık sayısı end*
					
				}
				
				//ilk açılış çizmi
				else{
										
					//rüzgar kolonu ve arakat kolonu bulma
					if(settings.KismiAraKatEkle == true){
						
						if(((settings.Boy) / settings.stepBoy) == settings.araKatUzunlugu){
							
							ruzgarKolonSayisi = 0;
							arakatKolon = 8;
						}
						else{
							
							ruzgarKolonSayisi = 1;
							arakatKolon = settings.araKatUzunlugu + 1;
						}
					}
					else{
						
						ruzgarKolonSayisi = 2;
						arakatKolon = 0;
					}

					//ara kat kirisi bulma
					//tali kiriş bulma
					if(settings.AraKatEkle == true){
						
						taliKiris = 3 * 7;
						arakatKiris = 8 * 2;
						ttPlak = 10 * 7;
					}
					else{
						
						
					}
					
					if(settings.KismiAraKatEkle == true){
							
						taliKiris = 3 * settings.araKatUzunlugu;
						arakatKiris = 2 * (settings.araKatUzunlugu + 1);
						ttPlak = 10 * settings.araKatUzunlugu;
					}
					else{
						
					}
					
					//tali kiriş bulma
					//ara kat kirisi bulma
					
					//vinç kiriş yerleri bulma
					
					if(settings.VincliKolonlar === true){
						
						vincKirisYeriEn = 'A-B';
						vincKirisYeriBoy = '1-7';
					}
					else{
						
						//vinç konsolları açık değil
					}
					//vinç kiriş yerleri bulma

					//**ara kat yerleri bulma
					if(settings.AraKatEkle ==  true){
					   
						araKatYeriEn = 'A-B';
						araKatYeriBoy = '1-7';
						
					}
					
					if(settings.KismiAraKatEkle == true){
						/*
						if(settings.araKatGenisligi == 1){
							
							var araKatYeriEn = 'A-B';
						}
						else if(settings.araKatGenisligi == 2){
							
							var araKatYeriEn = 'A-C';
						}
						else if(settings.araKatGenisligi == 3){
							
							var araKatYeriEn = 'A-D';
						}
						else if(settings.araKatGenisligi == 4){
							
							var araKatYeriEn = 'A-E';
						}*/
						
						araKatYeriEn = 'A-B';
						
						var araKatYeriBoyIkinciDegisken = settings.araKatUzunlugu + 1;
						araKatYeriBoy = '1-' + araKatYeriBoyIkinciDegisken;
						
					}
					//**ara kat yerleri bulma
					
					if(settings.AraKatEkle === false){
						
						//console.log("Kolon Stand Sayısı: " + settings.kolonStandSayisi);
					}
					
					else{
						
						console.log("Kolon Stand Sayısı: " + 24);
					}
					
					if((settings.KismiAraKatEkle === false) || (settings.kismiAraKatKaldir === true)){
						
						//console.log("Kısmi Ara Kat: " + settings.KismiaraKatSayisi);
					}
					/*this.araKatUzunlugu = 1,
					this.araKatGenisligi = 1,*/
					if(settings.KismiAraKatEkle === true){
						
						kismiAraKatHolSayisi = 1;
						
						kismiAraKatAksSayisi = settings.araKatUzunlugu;
						
						kismiAraKatHolBoyutu = (settings.araKatGenisligi * settings.stepEn);
						
						kismiAraKatAksBoyutu =  (settings.araKatUzunlugu * settings.stepBoy);

						//console.log("Kısmı Ara Kat: " + " Var, HolxAks: " + settings.araKatGenisligi + "x" + settings.araKatUzunlugu + " Boyutları: " + kismiAraKatHolBoyutu + "x" + kismiAraKatAksBoyutu);
					}
					
					if(settings.AraKatEkle === false){
						
						//console.log("Komple Ara Kat: " + settings.araKatSayisi);
					}
					
					else{
						
						KompleAraKatHolSayisi = 1;
							
						KompleAraKatHolBoyutu = settings.En + "x" + settings.Boy;
						
						//console.log("Komple Ara Kat: " + "Var, " + KompleAraKatHolBoyutu + " Boyutlarında.");
					}
					
					
					if(settings.Vinc_Kirisleri_Ekle === false){
						
						//console.log("Vinc Kirisi Sayısı: " + settings.vincKirisiSayisi);
					}
					
					else{
						
						vincKirisiSayisi = 2 * ((settings.Boy) / settings.stepBoy);
						
						//console.log("Vinc Kirisi Sayısı: " + vincKirisiSayisi);
					}
				}
				settings.ankrajHesabi();
			}
			//obje ekleme ve kaldırma fonksiyonları son*
			
			//diğer tüm metreküpler(aşık-oluk-vinçkirişi)
			this.metreKupHesaplari = function(){
				
				if(settings.En < 31 && settings.Boy < 31 && settings.Yükseklik < 9){
					
					//aşık kirişi
					asikMetreKupT = taneAsikMetreKup2 * asikSayisi;
					console.log("aşık sayısı: " + asikSayisi + " aşık metreküp: " + asikMetreKupT);
					console.log("********");

					//oluk kirişi
					olukMetreKup = taneOlukMetreKup2 * olukSayisi;
					console.log("oluk sayısı: " + olukSayisi + " oluk metreküp: " + olukMetreKup);
					console.log("********");

					//vinç kirişi
					vincKirisiMetreKup = taneVincMetreKup2 * vincKirisiSayisi.toFixed(0);
					console.log("vinç kiriş sayısı: " + vincKirisiSayisi.toFixed(0) + " vinç kiriş metreküp: " + vincKirisiMetreKup);
					console.log("********");
				}
				
				else{

					//aşık kirişi
					asikMetreKupT = taneAsikMetreKup * asikSayisi;
					console.log("aşık sayısı: " + asikSayisi + " aşık metreküp: " + asikMetreKupT);
					console.log("********");

					//oluk kirişi
					olukMetreKup = taneOlukMetreKup * olukSayisi;
					console.log("oluk sayısı: " + olukSayisi + " oluk metreküp: " + olukMetreKup);
					console.log("********");

					//vinç kirişi
					vincKirisiMetreKup = taneVincMetreKup * vincKirisiSayisi.toFixed(0);
					console.log("vinç kiriş sayısı: " + vincKirisiSayisi.toFixed(0) + " vinç kiriş metreküp: " + vincKirisiMetreKup);
					console.log("********");
				}
			}
			
			//makas metreküp hesabı
			this.makasMetreKupHesabi = function(){
				
				if(settings.En < 31 && settings.Boy < 31 && settings.Yükseklik < 9){
					
					makasMetreKup = taneMakasMetreKup2 * makasSayisi;
					console.log("makas sayısı: " + makasSayisi + ", makas metreküp: " + makasMetreKup);
					console.log("*******");
				}
				
				else{
					
					makasMetreKup = taneMakasMetreKup * makasSayisi;
					console.log("makas sayısı: " + makasSayisi + ", makas metreküp: " + makasMetreKup);
					console.log("*******");
				}
			}
			
			//kolon metreküp hesabı
			this.kolonMetreKupHesabi = function(){
				
				if(settings.AraKatEkle === true){
									
					kolonMetreKup = taneKolonMetreKup * arakatKolon;
					
					console.log("kolon sayısı: " + kolonSayisi + ", rüzgar kolon sayısı: " + ruzgarKolonSayisi + " arakat kolon sayısı: " + arakatKolon + ", Toplam Kolon Metreküp: " + kolonMetreKup);
					console.log("****komple arakat ekli***");
				}
				
				else if(settings.KismiAraKatEkle === true && settings.kismiAraKatKaldir === false){
					/*
					kolonMetreKup = (taneKolonMetreKup * kolonSayisi) + (taneRuzgarKolonMetreKup * ruzgarKolonSayisi) + (arakatKolonMetreküp * (kolonSayisi - arakatKolon));*/
					
					if((settings.araKatGenisligi == ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn)) && (settings.araKatUzunlugu == ((settings.Boy - (settings.Boy % settings.stepBoy)) / settings.stepBoy))){
						
						kolonMetreKup = taneKolonMetreKup * arakatKolon;
					
						console.log("kolon sayısı: " + kolonSayisi + ", rüzgar kolon sayısı: " + ruzgarKolonSayisi + " arakat kolon sayısı: " + arakatKolon + ", Toplam Kolon Metreküp: " + kolonMetreKup);
						console.log("****kısmi arakat ekli - genislik ve uzunluk full***");
					}
					
					else{
												
						var arakatsizKolon = parseInt(kolonSayisi) + parseInt(ruzgarKolonSayisi) - parseInt(arakatKolon);
					
						kolonMetreKup = (arakatsizKolon * taneKolonMetreKup) + (arakatKolon * taneKolonMetreKup) + (ruzgarKolonSayisi * taneRuzgarKolonMetreKup);

						console.log("kolon sayısı: " + kolonSayisi + ", rüzgar kolon sayısı: " + ruzgarKolonSayisi + " arakat kolon sayısı: " + arakatKolon + " arakatsız kolon sayısı: "+ arakatsizKolon + ", Toplam Kolon Metreküp: " + kolonMetreKup);
						console.log("****kısmi arakat ekli***");
					}
				}
				
				else if(settings.AraKatEkle === false && settings.KismiAraKatEkle === false){
					
					kolonMetreKup = (taneKolonMetreKup * kolonSayisi) + (taneRuzgarKolonMetreKup * ruzgarKolonSayisi);
					
					console.log("kolon sayısı: " + kolonSayisi + ", rüzgar kolon sayısı: " + ruzgarKolonSayisi + " arakat kolon sayısı: " + arakatKolon + ", Toplam Kolon Metreküp: " + kolonMetreKup);
					console.log("***arakat yok****");
				}
			}

			this.metrajHesabi = function(){
				
				console.log("stepBoy: " + settings.stepBoy + " stepEn: " + settings.stepEn);
				
				//oluk metraj
				ongermeHalatiOluk = olukSayisi * settings.stepBoy * 1.548;
				ongermeHalatiAsik = asikSayisi * settings.stepBoy * 1.548;
				ongermeHalatiMakas = makasSayisi * settings.stepEn * 8.808;
				
				if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
					
					ongermeHalatiAraKatKiris = arakatKiris.toFixed(0) * (settings.stepBoy / 3) * 8.808;
					ongermeHalatiPiplak = ttPlak * (settings.stepBoy / 3) * 4.404;
					console.log("3e BÖLÜNDÜ!!!!!!!!!!!!!!");
				}
				
				else{
					
					ongermeHalatiAraKatKiris = arakatKiris.toFixed(0) * (settings.stepBoy / 2) * 8.808;
					ongermeHalatiPiplak = ttPlak * (settings.stepBoy / 2) * 4.404;
					console.log("2ye BÖLÜNDÜ");
				}
				
				 
				
				
				ongermeHalatiToplam = ongermeHalatiOluk + ongermeHalatiAsik + ongermeHalatiAraKatKiris + ongermeHalatiPiplak + ongermeHalatiMakas;
				
				ongermeHalatiKarkas = ongermeHalatiOluk + ongermeHalatiAsik + ongermeHalatiMakas;
				
				console.log("****");
				console.log("ongermeHalatiOluk: " + ongermeHalatiOluk);
				console.log("oluk sayısı: " + olukSayisi);
				console.log("stepBoy: " + settings.stepBoy);
				console.log("****");
				console.log("ongermeHalatiAsik: " + ongermeHalatiAsik);
				console.log("araKat kirişi öngerme toplam: " + ongermeHalatiAraKatKiris);
				console.log("ongermeHalatiPiplak: " + ongermeHalatiPiplak);
				console.log("Makas öngerme halatı: " + ongermeHalatiMakas);
				console.log("Öngerme halatı toplam: " + ongermeHalatiToplam);
				console.log("Öngerme halatı karkas: " + ongermeHalatiKarkas);
			}

			this.ankrajHesabi = function(){
			
				ankrajToplam = (arakatKiris + taliKiris) * 2;
				console.log("ankraj toplamı: " + ankrajToplam);
			}

			this.ttPlakMetreKupHesabi = function(){
				
				var tempTtPlakMetreKup30 = ttPlakYukseklik3045 * ((settings.stepEn / 3) / Math.ceil((settings.stepEn / 3) / 2.35));
				var tempTtPlakMetreKup45 = ttPlakYukseklik3045 * ((settings.stepEn / 3) / Math.ceil((settings.stepEn / 3) / 2.35));
				var tempTtPlakMetreKup70 = ttPlakYukseklik70 * ((settings.stepEn / 3) / Math.ceil((settings.stepEn / 3) / 2.35));
				
				console.log("70lik ttplak: " + tempTtPlakMetreKup70);
				console.log("ttplak sayısı: " + ttPlak);

				ttPlakMetreKup30 = (tempTtPlakMetreKup30 + ((0.125 * 0.25 * 1) * 2)) * ttPlak * settings.stepBoy;
				ttPlakMetreKup45 = (tempTtPlakMetreKup45 + ((0.125 * 0.4 * 1) * 2)) * ttPlak * settings.stepBoy;
				ttPlakMetreKup70 = (tempTtPlakMetreKup70 + ((0.125 * 0.6 * 1) * 2)) * ttPlak * settings.stepBoy;
				
				console.log("ttplakMetreKup: " + ttPlakMetreKup30 + " - " + ttPlakMetreKup45 + " - " + ttPlakMetreKup70);
			}
		}
		
        //GUI settings
        var settings = new Settings();
        app.gui = new dat.GUI({

			closed: true,
			opacity: 0.5,
			width: 323,
		});
		
		var obj = {
			
			change : function(){

				  	settings.redraw();
				  },

			kismiAraKatEkle: function(){
				
					settings.ttPlakMetreKupHesabi();
				
					if((settings.araKatGenisligi > (settings.En / settings.stepEn)) || (settings.araKatUzunlugu > (settings.Boy / settings.stepBoy))){
					   
						   alert("Kısmi Arakat değerlerinizde bir yanlışlık olmalı, lütfen yeni değerler girerek tekrar deneyin. Binanın şuanki boyutlarına göre verebileceğiniz maksimum değerler: Arakat Genişliği: " + ((settings.En - (settings.En % settings.stepEn)) / settings.stepEn).toFixed(0) + ", Arakat Uzunluğu: " + ((settings.Boy) / settings.stepBoy).toFixed(0));
						
						   settings.KismiAraKatEkle = false;
					}
				
				
					else{
						//kısmi ara katla alakalı her objeyi silme kısmı
					  	settings.kismiAraKatKolonlariEkle();
					  
					  	for(var i = -2; i < settings.araKatGenisligi * 6; i++){
								
							var selectedItem1 = app.scene.getObjectByName("hoho2" + i);
							app.scene.remove(selectedItem1);
								
							for(var j = -3; j < settings.araKatUzunlugu * 6; j++){
									
								var selectedItem1 = app.scene.getObjectByName("hoho" + i + j);
								app.scene.remove(selectedItem1);
							}
						}

						var selectedItem1 = app.scene.getObjectByName("KismiaraKat" + 1);
						app.scene.remove(selectedItem1); 
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat1" + 2);
						app.scene.remove(selectedItem1); 
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat2" + 3);
						app.scene.remove(selectedItem1); 
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat3" + 4);
						app.scene.remove(selectedItem1);

					  	for(var i = - 2; i <= settings.araKatGenisligi * 6; i++){
									
							for(var j = - 3; j <= settings.araKatUzunlugu * 6; j++){
								
								var selectedItem1 = app.scene.getObjectByName("kolonAltlikKismiAraKat" + i + j);
								app.scene.remove(selectedItem1);
							}
						}
					  	
					  	for(var i = -2; i <= settings.araKatGenisligi * 6; i++){

							for(var j = -3; j <= settings.araKatUzunlugu *6; j++){
								
								var selectedItem1 = app.scene.getObjectByName("KismiaraKatDestek" + i + j);
								app.scene.remove(selectedItem1);
							}
						}
					  //kısmi ara katla alakalı her objeyi silme kısmı bitiş
					  
					  //arakat destek kolonları ekleme -if hol 3e bölünüyorsa-
					  if(settings.stepEn / 3 >= 7 || (settings.En >= 60 && settings.En <= 63) || (settings.En >= 21 && settings.En <=	27.1 ) || (settings.En > 40 && settings.En <= 44)){
						  
						for(var i = 0; i < settings.araKatGenisligi * 3; i++){

							for(var j = 0; j <= settings.araKatUzunlugu - 1; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 3) + (settings.stepEn / 3) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "KismiaraKatDestek" + i + j;
								app.scene.add(object);
							}
						}
					
					  //arakat destek kolonları ekleme bitiş
					  
					  //Obj alt bölümleri ekleme
							var manager = new THREE.LoadingManager();
							var mtlLoader = new THREE.MTLLoader();
							var objLoader = new THREE.OBJLoader();
							var fileloader = new THREE.FileLoader();
							var objLoader = new THREE.OBJLoader(manager);
							
							fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){

								for(var i = 0; i < settings.araKatGenisligi * 3; i++){
									
									for(var j = 1; j < settings.araKatUzunlugu + 1; j++){
									
									var object = objLoader.parse(data);
									object.position.set(((settings.stepEn / 3) * (i + 1)), 0, - 2 - (settings.stepBoy * j));
									object.name = "kolonAltlikKismiAraKat" + i + j;
									object.scale.set(0.21, 0.21, 0.21);
									object.traverse(function (child){

									if(child instanceof THREE.Mesh)
										child.material.color.setHex(0x969696);
									});
									app.scene.add(object);
									}
								}
							},
								function(xhr){
 
									// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
								},
									//if download fails
								function(xhr){

									   // console.error('An error happened : ' + xhr);
								}
							);
					  }
					  //arakat destek kolonları ekleme -if hol 3e bölünüyorsa- 
					  else{
						  
						  for(var i = 0; i < settings.araKatGenisligi * (3/2); i++){

							for(var j = 0; j <= settings.araKatUzunlugu - 1; j++){

								var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
								object.position.set((settings.stepEn / 2) + (settings.stepEn / 2) * i, (settings.Yükseklik / 4.7), - ((j + 1) * settings.stepBoy));
								object.scale.set(0.2, settings.Yükseklik / 11.2, 0.2);
								object.name = "KismiaraKatDestek" + i + j;
								app.scene.add(object);
							}
						}
					
					  //arakat destek kolonları ekleme bitiş
					  
					  //Obj alt bölümleri ekleme
							var manager = new THREE.LoadingManager();
							var mtlLoader = new THREE.MTLLoader();
							var objLoader = new THREE.OBJLoader();
							var fileloader = new THREE.FileLoader();
							var objLoader = new THREE.OBJLoader(manager);
							
							fileloader.load('https://www.betonel.com.tr/teklifal/blenderObjects/kolonAltlik.obj', function(data){

								for(var i = 0; i < settings.araKatGenisligi * (3/2); i++){
									
									for(var j = 1; j < settings.araKatUzunlugu + 1; j++){
									
									var object = objLoader.parse(data);
									object.position.set(((settings.stepEn / 2) * (i + 1)), 0, - 2 - (settings.stepBoy * j));
									object.name = "kolonAltlikKismiAraKat" + i + j;
									object.scale.set(0.21, 0.21, 0.21);
									object.traverse(function (child){

									if(child instanceof THREE.Mesh)
										child.material.color.setHex(0x969696);
									});
									app.scene.add(object);
									}
								}
							},
								function(xhr){
 
									// console.log((xhr.loaded / xhr.total * 100) + '% loaded');
								},
									//if download fails
								function(xhr){

									   // console.error('An error happened : ' + xhr);
								}
							);
						  //boş bırak şimdilik.
					  }
											
							//Obj alt bölümleri ekleme bitiş

						if(settings.araKatGenisligi === 1){
							
							//ara kat genişliği == 1  olduğu zaman oluşturulacak ara katlar.
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));

							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}

							else if(settings.araKatUzunlugu === 1){
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu === 7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}

							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat" + 1;
							app.scene.add(object);
						
						}
					  
						else if(settings.araKatGenisligi === 0){
							
						}
						
						else if(settings.araKatGenisligi === 2){
							
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));

							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}

							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){
								
								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}

							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat" + 1;
							app.scene.add(object);

							
							
							//ara kat genişliği 2 olduğu zaman bir sonraki arakatlar.
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu === 7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat1" + 2;
							app.scene.add(object);

						}
						
						else if(settings.araKatGenisligi === 3){
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));

							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}

							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu === 7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}

							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat" + 1;
							app.scene.add(object);							
							
							//ara kat genişliği 2 olduğu zaman bir sonraki arakatlar.
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu === 7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat1" + 2;								
							app.scene.add(object);	
							
							//var selectedItem1 = app.scene.getObjectByName("KismiaraKat1" + (sayac - 1));
							//app.scene.remove(selectedItem1);
							
							//3. katman ara katlar
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat2" + 3;
							app.scene.add(object);
							
						}
						
						else if(settings.araKatGenisligi === 4){
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));

							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}

							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (1)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}

							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat" + 1;								
							app.scene.add(object);
	
							//ara kat genişliği 2 olduğu zaman bir sonraki arakatlar.
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (2)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat1" + 2;								
							app.scene.add(object);
							
							//var selectedItem1 = app.scene.getObjectByName("KismiaraKat1" + (sayac - 1));
							//app.scene.remove(selectedItem1);
							
							//3. katman ara katlar
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (3)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat2" + 3;
							app.scene.add(object);
							
							//4. katman
							
							var object = new THREE.Mesh(geometry, new THREE.MeshLambertMaterial({}));
							
							if(settings.araKatUzunlugu === 2){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy));
							}
						
							else if(settings.araKatUzunlugu === 1){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 2));
							}

							else if(settings.araKatUzunlugu === 3){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.68));
							}

							else if(settings.araKatUzunlugu === 4){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.5));
							}

							else if(settings.araKatUzunlugu === 5){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.4));
							}

							else if(settings.araKatUzunlugu === 6){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.33));
							}

							else if(settings.araKatUzunlugu ===7){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.28));
							}
							
							else if(settings.araKatUzunlugu === 8){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.25));
							}
							
							else if(settings.araKatUzunlugu === 9){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.22));
							}
							
							else if(settings.araKatUzunlugu === 10){

								object.position.set(0 - (settings.stepEn / 2) + (settings.stepEn * (4)), settings.Yükseklik / 2.25, - (settings.stepBoy / 0.2));
							}
							
							object.scale.set(- 0.1 + ((settings.stepEn * 1) / 5.2), 0.1, (settings.stepBoy * settings.araKatUzunlugu) / 5);
							object.name = "KismiaraKat3" + 4;
							app.scene.add(object);
						}

					  else{
						
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat" + 1);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat2" + 3);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat1" + 2);
						app.scene.remove(selectedItem1);
						var selectedItem1 = app.scene.getObjectByName("KismiaraKat3" + 4);
						app.scene.remove(selectedItem1);
						  
					  }}
				},

			kismiAraKatKaldir: function(){
					  
					settings.objeSayisiniBul();
					settings.redraw();
					settings.ankrajHesabi();
				  },

			BinaCiz: function () {
				debugger;
				settings.KismiAraKatEkle = false;
				settings.redraw();
				settings.objeSayisiniBul();
				settings.metreKupHesaplari();
				settings.ttPlakMetreKupHesabi();
				settings.kolonMetreKupHesabi();
				settings.makasMetreKupHesabi();
				settings.metrajHesabi();
				settings.ankrajHesabi();
				VincKontrol.open();
				araKatFolder.open();
				
				console.log("**********************////**************************/////**************************////*******************");
				
				console.log("vinç kirişi metreküp: " + vincKirisiMetreKup);
				console.log("oluk metreküp: " + olukMetreKup.toFixed(2));
				console.log("aşık metreküp: " + asikMetreKupT.toFixed(2));
				console.log("makas metreküp: " + makasMetreKup.toFixed(2));
				console.log("kolon metreküp: " + kolonMetreKup.toFixed(2));
				console.log("öngermeli halat toplam: " + ongermeHalatiToplam.toFixed(2));
				console.log("ankraj: " + ankrajToplam);
				console.log("ttPlakMetreKup30: " + ttPlakMetreKup30);
				console.log("ttPlakMetreKup45: " + ttPlakMetreKup45);
				console.log("ttPlakMetreKup70: " + ttPlakMetreKup70);
			},

			teklifAl: function(){
				
				if (confirm("Binanızın PDF'de gözükecek halini kabul ediyor musunuz? Yönünü değiştirmek için İPTAL e tıklayın.") == true) {
					
					
					document.getElementById('gonderBoy').value = settings.Boy.toFixed(2);
				
				document.getElementById('gonderEn').value = settings.En.toFixed(2);
		
				if(settings.KismiAraKatEkle === false){
					
					kismiAraKatHolSayisi = 0;
					kismiAraKatAksSayisi = 0;
					kismiAraKatHolBoyutu = 0;
					kismiAraKatAksBoyutu = 0;
				}
				
				settings.objeSayisiniBul();
				settings.metreKupHesaplari();
				settings.makasMetreKupHesabi();
				settings.kolonMetreKupHesabi();
				settings.metrajHesabi();
				settings.ankrajHesabi();
				
				var img = new Image();
				app.renderer.render(app.scene, app.camera);
				img.src = app.renderer.domElement.toDataURL();

				if(settings.AraKatEkle === true || settings.KismiAraKatEkle === true){
					
					settings.ttPlakMetreKupHesabi();
				}

				console.log("30luk ttPlak: " + ttPlakMetreKup30 + "45lik ttPlak: " + ttPlakMetreKup45 + "70lik ttPlak: " + ttPlakMetreKup70);
				
				var myJSON = JSON.stringify(img);

				$.ajax({
					
					  type: "POST",
					
					  url: "http://www.betonel.com.tr/teklifal/create-form.php",
					
					  contentType: "application/x-www-form-urlencoded; charset=UTF-8",
					
					  data:{
						  
						 imgBase64: img.src
					  }
					}).done(function(o){
					
					  	console.log('saved');

						window.location.assign('http://www.betonel.com.tr/teklifal/create-form.php?boy='+ document.getElementById('gonderBoy').value + '&en=' + document.getElementById('gonderEn').value + '&yukseklik=' + settings.Yükseklik + '&vincliKolonlar=' + settings.VincliKolonlar + '&vincKirisleri=' + settings.Vinc_Kirisleri_Ekle + '&vincKirisSayisi=' + vincKirisiSayisi.toFixed(0) + '&kolonSayisi=' + kolonSayisi + '&ruzgarKolonSayisi=' + ruzgarKolonSayisi + '&standSayisi=' + tumStandSayisi + '&olukSayisi=' + olukSayisi + '&makasSayisi=' + makasSayisi + '&kompleAraKat=' + settings.AraKatEkle + '&KompleAraKatHolSayisi=' + KompleAraKatHolSayisi + '&KompleAraKatHolBoyutu=' + KompleAraKatHolBoyutu + '&kismiAraKat=' + settings.KismiAraKatEkle + '&kismiAraKatHolSayisi=' + kismiAraKatHolSayisi + '&kismiAraKatAksSayisi=' + kismiAraKatAksSayisi + '&kismiAraKatHolBoyutu=' + kismiAraKatHolBoyutu + '&kismiAraKatAksBoyutu=' + kismiAraKatAksBoyutu + '&genelHolSayisi=' + genelHolSayisi + '&asikSayisi=' + asikSayisi + '&vincKirisYeriEn=' + vincKirisYeriEn + '&vincKirisYeriBoy=' + vincKirisYeriBoy + '&araKatYeriEn=' + araKatYeriEn + '&araKatYeriBoy=' + araKatYeriBoy + '&ttPlak=' + ttPlak.toFixed(0) + '&taliKiris=' + taliKiris.toFixed(0) + '&arakatKiris=' + arakatKiris.toFixed(0) + '&arakatKolon=' + arakatKolon.toFixed(0) + '&imgBase64=' + '&vincKirisiMetreKup=' + vincKirisiMetreKup + '&olukMetreKup=' + olukMetreKup.toFixed(2) + '&asikMetreKupT=' + asikMetreKupT.toFixed(2) + '&makasMetreKup=' + makasMetreKup.toFixed(2) + '&kolonMetreKup=' + (kolonMetreKup).toFixed(2) + '&ongermeHalatiToplam=' + ongermeHalatiToplam.toFixed(2) + '&ankrajToplam=' + ankrajToplam + '&ttPlakMetreKup30=' + ttPlakMetreKup30 + '&ttPlakMetreKup45=' + ttPlakMetreKup45 + '&ttPlakMetreKup70=' + ttPlakMetreKup70 + '&ongermeHalatiKarkas=' + ongermeHalatiKarkas + '&ongermeHalatiAraKatKiris=' + ongermeHalatiAraKatKiris);
					});
					
				} else {
					
					alert("Mous'unuzun sol tıkı ile binanın yönünü değiştirebilir, sağ tıkı ile ise yakınlık-uzaklık değerlerini değiştirebilirsiniz.");
				}
				
				
				
			}
		};

        if(grid){

			//boyutlandırma folderı*
			var boyutlandirma = app.gui.addFolder('Bina Boyutlandırma');

			boyutlandirma.add(settings, 'Boy').min(5).max(100).step(0.01).name('Bina Boy').onChange(function(value){

                settings.Boy = value;
            });

			boyutlandirma.add(settings, 'En').min(5).max(100).step(0.01).name('Bina Genişliği (En)').onChange(function(value){

				settings.En = value;
            });

			boyutlandirma.add(settings, 'Yükseklik').min(3).max(28).step(0.01).name('Bina Yüksekliği').onChange(function(value){

				settings.Yükseklik = value;
			});

			boyutlandirma.add(obj, 'BinaCiz').name('Binayı Boyutlandır ' + ' (Uzunluk - Genişlik - Yükseklik)');

			boyutlandirma.open();
 			//boyutlandırma folderı end*
			
			

			//Vinç Kontrol*
			var VincKontrol = app.gui.addFolder('Vinçli Kolon ve Vinç Kirişleri');
				
			VincKontrol.add(settings, 'VincliKolonlar').name('Vinçli Kolonlar').onChange(function(k){
                    
                if(k === true){
                    
                	settings.kolEkle();
					
					if(settings.Vinc_Kirisleri_Ekle == true){
						
						settings.VincKirisiEkle();
					}
					else{
						
						settings.VincKirisleriKaldir();
					}
                }
                
                else{
					
					settings.VincsizKolonEkle();
					settings.VincKirisleriKaldir();
                }
            });

			VincKontrol.add(settings, 'Vinc_Kirisleri_Ekle').name('Vinç Kirişleri Ekle').onChange(function(y){
					
				if(y === true){
					
					settings.VincKirisiEkle();
					settings.objeSayisiniBul();
					settings.metreKupHesaplari();
					settings.makasMetreKupHesabi();
					settings.kolonMetreKupHesabi();
					settings.metrajHesabi();
				}	
					
				else{
					
					settings.VincKirisleriKaldir();
					settings.objeSayisiniBul();
					settings.metreKupHesaplari();
					settings.makasMetreKupHesabi();
					settings.kolonMetreKupHesabi();
					settings.metrajHesabi();
				}
			});

			//VincKontrol.close();
			//Vinç Kontrol end*

			//ara kat folderı*
			var araKatFolder = app.gui.addFolder('Ara Kat Ekleme/Kaldırma');

			araKatFolder.add(settings, 'AraKatEkle').name('Komple Ara Kat Ekle').onChange(function(z){
					
				if(z === true){
					
					settings.AraKatEkleme();
					obj.kismiAraKatKaldir();
					settings.objeSayisiniBul();
					settings.kismiAraKatKaldir = true;
					settings.KismiAraKatEkle = false;
					settings.ttPlakMetreKupHesabi();
					settings.metrajHesabi();
				}
					
				else{
					
					ttPlak = 0;
					taliKiris = 0;
					arakatKiris = 0;
					//settings.redraw();
					settings.AraKatKaldir();
					settings.objeSayisiniBul();
					settings.ttPlakMetreKupHesabi();
					settings.metrajHesabi();
					
					if(settings.VincliKolonlar === true){
				   
						if(settings.En / settings.stepEn > 1){

							settings.VincliOrtaKolonEkle();
						}
						else{

							settings.kolEkle();
						}
					}
					else{
					
						if(settings.En / settings.stepEn > 1){

							settings.VincsizOrtaKolonEkle();
						}
						
						else{

							settings.VincsizKolonEkle();
						}
					}
				}
			});

			araKatFolder.add(settings, 'araKatUzunlugu').min(1).max(10).step(1).name('Kısmi Ara Kat Uzunluğu (Kaç Aks Olduğu)').onFinishChange(function(value){
				
				settings.araKatUzunlugu = value;
				//obj.kismiAraKatEkle();
			});

			araKatFolder.add(settings, 'araKatGenisligi').min(1).max(4).step(1).name('Kısmi Ara Kat Genişliği (Kaç Hol olduğu)').onFinishChange(function(value){
				
				settings.araKatGenisligi = value;
				//obj.kismiAraKatEkle();
			});

			araKatFolder.add(settings, 'KismiAraKatEkle').name('Kısmi Ara Kat Ekle').onChange(function(m){
				
				settings.KismiAraKatEkle = true;
				settings.kismiAraKatKaldir = false;
				obj.kismiAraKatEkle();
				settings.objeSayisiniBul();
				settings.kolonMetreKupHesabi();
				
			});

			araKatFolder.add(settings, 'kismiAraKatKaldir').name('Kısmi Ara Katları Kaldır').onChange(function(w){
				
				ttPlak = 0;
				taliKiris = 0;
				arakatKiris = 0;
				settings.kismiAraKatKaldir = true;
				settings.KismiAraKatEkle = false;
				obj.kismiAraKatKaldir();
				settings.objeSayisiniBul();
			});

			//araKatFolder.open();
			//ara kat folderı end*

			app.gui.add(obj, 'change').name('Çizimi Tekrar Oluştur.');
			
			var teklifAl = app.gui.addFolder('');
			
			
			//teklifAl.open();
			/*
			//GUI kontrol text manipülasyonu <renk, boyut, button>
			  	app.gui.__ul.childNodes[3].childNodes[0].childNodes[0].classList += ' reset_button';
				araKatFolder.__ul.childNodes[4].childNodes[0].childNodes[0].classList += ' kontrol_buttons';
				araKatFolder.__ul.childNodes[5].childNodes[0].childNodes[0].classList += ' kontrol_buttons';
				boyutlandirma.__ul.childNodes[4].childNodes[0].childNodes[0].classList += ' kontrol_buttons';
				teklifAl.__ul.childNodes[1].childNodes[0].childNodes[0].classList += ' teklif_button';*/
				
				
				app.gui.__ul.childNodes[3].childNodes[0].childNodes[0].classList.add('reset_button');
				araKatFolder.__ul.childNodes[4].childNodes[0].childNodes[0].classList.add('kontrol_buttons');
				araKatFolder.__ul.childNodes[5].childNodes[0].childNodes[0].classList.add('kontrol_buttons');
				boyutlandirma.__ul.childNodes[4].childNodes[0].childNodes[0].classList.add('kontrol_buttons');
        }

		//ekran ve grid oluşturulduktan sonra ilk kenar kolonlarını da oluştur.
		settings.objeSayisiniBul();
		settings.VincsizKolonEkle();
		//ilk grid oluşumu, özellikler.js'ye ilk değerleri yolla.
        app.grid = new LabeledGrid(60, 20, (60/ (60/10)), (60/ (60/30+1)), 13, [0,1,0], 0x000055, 0.21,  true, "#000000", "left");
        app.scene.add(app.grid);
        return app;
    }
	
    static setupRenderer(container){

        const size={

            width: container.clientWidth,
            height: container.clientHeight
        };

        const renderer = new THREE.WebGLRenderer({
            
            antialias: true, alpha: true, preserveDrawingBuffer: true
        });

        renderer.setSize(size.width, size.height);
        container.appendChild(renderer.domElement);
        return renderer;
    }

    static onWindowResize(e){
		
        let app = ThreeUtils.app;
        var size = {
			
            width:  app.container.clientWidth,
            height: app.container.clientHeight
        };
        app.renderer.setSize(size.width / 1, size.height / 1);
        app.camera.aspect = size.width / size.height;
        app.camera.updateProjectionMatrix();
    }

    static animate(){

        let app = ThreeUtils.app;
        app.controls.update();
        requestAnimationFrame(ThreeUtils.animate);

        if (app.frame) app.frame();
        app.renderer.render(app.scene, app.camera);
    }
}