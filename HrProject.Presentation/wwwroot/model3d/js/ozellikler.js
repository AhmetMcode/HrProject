class LabeledGrid extends THREE.Object3D{
		
    constructor(width = 200, length = 200, stepBoy = 100, stepEn = 130, yukseklik = 13, upVector = [0,1,0], color = 0x00baff, opacity = 0.2, text = true, textColor = "#000000", textLocation = "center"){
		
        super();
        this.width        =     width;
        this.length       =     length;
        this.stepBoy      =     stepBoy;
        this.stepEn       =     stepEn;
		this.yukseklik	  =		yukseklik;
        this.color        =     color;
        this.opacity      =     opacity;
        this.text         =     text;
        this.textColor    =     textColor;
        this.textLocation =     textLocation;
        this.upVector     =     new THREE.Vector3().fromArray(upVector);
      	
        this.name = "grid";
        //TODO: clean this up
        this.marginSize = 10;
        this.stepSubDivisions = 10;
      	
        this._drawGrid();
		
        var upVector = this.upVector;
        this.up = upVector;
        this.lookAt(upVector);
    }
  		
        _drawGrid(){
			
            var gridGeometry, gridMaterial, mainGridZ, planeFragmentShader, planeGeometry, planeMaterial, subGridGeometry, subGridMaterial, subGridZ;
            //dış grid opt.
            mainGridZ = -0.05;
            gridGeometry = new THREE.Geometry();
            gridMaterial = new THREE.LineBasicMaterial({
				
                color: new THREE.Color().setHex(this.color),
                opacity: this.opacity,
                linewidth: 5,
                transparent: true
            });

            var stepBoy = this.stepBoy;
            var stepEn = this.stepEn;
            var stepSubDivisions = this.stepSubDivisions;
            var width = this.width;
            var length = this.length;
			var yukseklik = this.yukseklik;
            var centerBased = true;

			//var a = width 
			
            if(centerBased){
				
                //width a,b altı grid çizgileri ve tam en gösterme gridi
                for(var i = - stepBoy; i <= width; i += stepBoy){
					
                    gridGeometry.vertices.push(new THREE.Vector3(0, i, mainGridZ)); //grid y ekseni 0'dan i kadar devam
                    gridGeometry.vertices.push(new THREE.Vector3(length - (length % stepEn), i, mainGridZ)); //length e kadar devam ediyor çizmeye
                }
				
				//hol en uzunluğu çizgisi
				for(var i = -(4 * stepBoy / 3 ); i <= -5; i += stepBoy){
					
                    gridGeometry.vertices.push(new THREE.Vector3(0, i, mainGridZ)); //grid y ekseni 0'dan i kadar devam
                    gridGeometry.vertices.push(new THREE.Vector3(stepEn , i, mainGridZ)); //length e kadar devam ediyor çizmeye
                }
				
				//z ekseni yükseklik çizgisi
				for(var i = 0; i <= 1; i++){
					
					//console.log(yukseklik);
					var v3a = new THREE.Vector3(-stepBoy, -stepBoy, yukseklik);
					var v3b = new THREE.Vector3(-stepBoy, -stepBoy, 0);
					gridGeometry.vertices.push(v3a);
					gridGeometry.vertices.push(v3b);
				}

				//tam boy gösterme gridi
				for(var i = 0; i <= 1; i ++){

					gridGeometry.vertices.push(new THREE.Vector3(i * (- stepBoy), 0, mainGridZ)); //x ekseninde i kadar ilerle sürekli
					gridGeometry.vertices.push(new THREE.Vector3(i * (- stepBoy), width, mainGridZ)); // 0 to width e kadar çiz.
				}
				
				//stepBoy uzunluk değerlerinin altına çizgi
				for(var i = 0.6; i <= 1; i ++){

					gridGeometry.vertices.push(new THREE.Vector3(- 6, 0, mainGridZ)); //x ekseninde i kadar ilerle sürekli
					gridGeometry.vertices.push(new THREE.Vector3(- 6, width, mainGridZ)); // 0 to width e kadar çiz.
				}

				for(var i = 0; i <= (length - (length % stepEn)) / stepEn; i ++){
																				
					gridGeometry.vertices.push(new THREE.Vector3(i * stepEn, 0, mainGridZ)); //x ekseninde i kadar ilerle sürekli
					gridGeometry.vertices.push(new THREE.Vector3(i * stepEn, width, mainGridZ)); // 0 to width e kadar çiz.
				}
				
				if(stepEn / 3 >= 7 || (length >= 60 && length <= 63) || (length >= 21 && length <=	27.1) || (length > 40 && length <= 44)){

					for (var i = 0; i <= length - (length % stepEn); i += stepEn / 3){

						gridGeometry.vertices.push(new THREE.Vector3(i, 0, mainGridZ));
						gridGeometry.vertices.push(new THREE.Vector3(i, width, mainGridZ));
					}
				}

				else{

					for (var i = 0; i <= length - (length % stepEn); i += stepEn / 2){
						
						gridGeometry.vertices.push(new THREE.Vector3(i, 0, mainGridZ));
						gridGeometry.vertices.push(new THREE.Vector3(i, width, mainGridZ));
					}
				}
            }
				
            this.mainGrid = new THREE.LineSegments(gridGeometry, gridMaterial);
            //sub grid geometry objesi oluşturma
            this.subGrid = new THREE.LineSegments(subGridGeometry, subGridMaterial);

            //create margin
            var offsetWidth  = width + this.marginSize;
            var offsetLength = length + this.marginSize;
            
            var marginGeometry = new THREE.Geometry();
            marginGeometry.vertices.push(new THREE.Vector3(-length / 2, -width / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(length / 2, -width / 2, subGridZ));

            marginGeometry.vertices.push(new THREE.Vector3(length / 2, -width / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3( length / 2,  width / 2, subGridZ));
      
            marginGeometry.vertices.push(new THREE.Vector3(length / 2,  width / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(-length / 2,  width / 2, subGridZ));
      
            marginGeometry.vertices.push(new THREE.Vector3(-length / 2,  width / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(-length / 2, -width / 2, subGridZ));
       		
            marginGeometry.vertices.push(new THREE.Vector3(-offsetLength / 2, -offsetWidth / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(offsetLength / 2, -offsetWidth / 2, subGridZ));
      		
            marginGeometry.vertices.push(new THREE.Vector3(offsetLength / 2, -offsetWidth / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(offsetLength / 2, offsetWidth / 2, subGridZ));
      		
            marginGeometry.vertices.push(new THREE.Vector3(offsetLength / 2, offsetWidth / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(-offsetLength / 2, offsetWidth / 2, subGridZ));
      		
            marginGeometry.vertices.push(new THREE.Vector3(-offsetLength / 2, offsetWidth / 2, subGridZ));
            marginGeometry.vertices.push(new THREE.Vector3(-offsetLength / 2, -offsetWidth / 2, subGridZ));
      
      
            var strongGridMaterial = new THREE.LineBasicMaterial({
				
                color: new THREE.Color().setHex(this.color),
                opacity: this.opacity * 0,
                linewidth: 2,
                transparent: true
            });
			
            this.margin = new THREE.LineSegments(marginGeometry, strongGridMaterial);
            //ekle grids, subgrids, margins ..
            this.add(this.mainGrid);
            this.add(this.subGrid);
            this.add(this.margin);
      		
            this._drawNumbering();
        }

        toggle(toggle){
            //apply visibility settings to all children
            this.traverse(function(child){
				
                child.visible = toggle;
            });
        }
	
        setOpacity(opacity){
			
            this.opacity = opacity;
            //this.mainGrid.material.opacity = opacity;
            this.subGrid.material.opacity = opacity / 2;
            this.mainGrid.material.opacity = opacity;
            this.margin.material.opacity = opacity * 2;
        }
		
        setColor(color){

            this.color = color;
            this.mainGrid.material.color = new THREE.Color().setHex(this.color);
            this.subGrid.material.color = new THREE.Color().setHex(this.color);
            this.margin.material.color = new THREE.Color().setHex(this.color);
        }
		
        toggleText(toggle){
			
            this.text = toggle;
            var labels = this.labels.children;
            for(var i = 0; i < this.labels.children.length; i++){
				
                var label = labels[i];
                label.visible = toggle;
            }
        }

        setTextColor(color){
			
            this.textColor = color;
            this._drawNumbering();
        }
		
        setTextLocation(location){
			
            this.textLocation = location;
            return this._drawNumbering();
        }
		
        setUp(upVector){
			
            this.upVector = upVector;
            this.up = upVector;
            this.lookAt(upVector);
        }
		
        //yeniden boyutlama fonksiyonu.
        resize(width, length, stepBoy, stepEn, yukseklik){
			
           	if(width && length && stepBoy && stepEn && yukseklik){
				
                var width = Math.max(width, 10);
                this.width = width;
      	
                var length = Math.max(length, 10);
                this.length = length;

                var stepBoy = Math.max(stepBoy, 1);
                this.stepBoy = stepBoy;

                var stepEn = Math.max(stepEn, 1);
                this.stepEn = stepEn;
				
				var yukseklik = Math.max(yukseklik, 1);
				this.yukseklik = yukseklik;
                
                //this.step = Math.max(this.step,5);
                
                this.remove(this.mainGrid);
                this.remove(this.subGrid);
                this.remove(this.margin);
                //this.remove(this.plane);
                return this._drawGrid();
            }
			
			else{
				
				alert("Yeni değerler işlenirken bir hata meydana geldi: Lütfen tarayıcınızı yeniden başlatın.")
			}
        }
		
		
        _drawNumbering(){
			
            var label, sizeLabel, sizeLabel2, xLabelsLeft, xLabelsRight, yLabelsBack, yLabelsFront;
            var stepBoy = this.stepBoy;
            var stepEn = this.stepEn;
			var yukseklik = this.yukseklik;
			
            this._labelStore = {};		      
	  	
            if(this.labels != null){
				
                this.mainGrid.remove(this.labels);
            }
			
            this.labels = new THREE.Object3D();
            var width = this.width;
            var length = this.length;
            var numbering = this.numbering = "centerBased";
            var labelsFront = new THREE.Object3D();
            var labelsSideRight = new THREE.Object3D();
			var labelsBack = new THREE.Object3D();
			var labelsSideLeft = new THREE.Object3D();
            
            //grid numaralandırma
            if(numbering == "centerBased"){
				
				//*Boy grid numaralandırma, 1, 2, 3, ... rightside
				for(var i = 1 ; i <= (width / stepBoy) + 1; i++){
					
                    var sizeLabel = this.drawTextOnPlane("" + i, 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(2.5 + length - (length % stepEn), 0.2 +  ((i - 1) * stepBoy), 0);
                    sizeLabel2.rotation.z = - Math.PI / 2;
                    labelsFront.add(sizeLabel2);
                }
				//leftside
				for(var i = 1 ; i <= (width / stepBoy) + 1; i++){
					
                    var sizeLabel = this.drawTextOnPlane("" + i, 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(-3.5, 0.2 +  ((i - 1) * stepBoy), 0);
                    sizeLabel2.rotation.z = -Math.PI / 2;
                    labelsFront.add(sizeLabel2);
                }
				//*Boy grid numaralandırma, 1, 2, 3, ...
				
				//toplam boy u yazdırma
				var sizeLabel = this.drawTextOnPlane("Uzunluk : " + width.toFixed(2) + " m", 32);
                var sizeLabel2 = sizeLabel.clone();
                sizeLabel2.position.set(-stepBoy, width / 2, 0);
                sizeLabel2.rotation.z = -Math.PI / 2;
                labelsFront.add(sizeLabel2);
				//
        	
				//stepBoy uzunluğunu Boy tarafına yazdırma
                for(var i = 0 ; i <= (width - 1); i += stepBoy){
					
                    var sizeLabel = this.drawTextOnPlane("" + Math.round(stepBoy * 100) / 100, 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(length - (length % stepEn) + 6, 4.3 +  i, 0);
                    sizeLabel2.rotation.z = - Math.PI / 2;
                    labelsFront.add(sizeLabel2);
                }
				
				for(var i = 0 ; i <= (width - 1); i += stepBoy){
					
                    var sizeLabel = this.drawTextOnPlane("" + Math.round(stepBoy * 100) / 100, 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(0 - 6, 4.3 +  i, 0);
                    sizeLabel2.rotation.z = - Math.PI / 2;
                    labelsFront.add(sizeLabel2);
                }
				
				//toplam en i ekrana yazdırma
                var sizeLabel = this.drawTextOnPlane("Genişlik : " + length.toFixed(2) + " m", 32);
                var sizeLabel2 = sizeLabel.clone();
                sizeLabel2.position.set(length / 2, - stepBoy, 0);
                sizeLabel2.rotation.z = 0;
                labelsSideLeft.add(sizeLabel2);
                //(Math.round(stepEn * 100) / 100)

                //en altında hol genişliğini ekrana yazdırma
                debugger;
				var sizeLabel = this.drawTextOnPlane("Hol Eni : " + (Math.round(((length  + (length % stepEn)) / (length / stepEn)) * 100) / 100) + " m", 32);
                var sizeLabel2 = sizeLabel.clone();
                sizeLabel2.position.set(stepBoy + 2, -(4 * stepBoy / 3), 0);
                sizeLabel2.rotation.z = 0;
                labelsSideLeft.add(sizeLabel2);
				//
				
				//z ekseni grid yüksekliğini ekrana yazdırma
				var sizeLabel = this.drawTextOnPlane("Yükseklik : " + (Math.round(yukseklik * 100) / 100) + " m", 32);
				sizeLabel2 = sizeLabel.clone();
				sizeLabel2.position.set(-stepBoy, -stepBoy, yukseklik / 2);
				sizeLabel2.rotation.z = 1.58;
				sizeLabel2.rotation.x = 1.6;
				sizeLabel2.rotation.y = 0;
				labelsSideLeft.add(sizeLabel2);
				//
				
                for(var i = 0 ; i <= length - (length % stepEn); i += stepEn){

                    var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn), 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(0 + i, (width) + 2.3, 0);
                    sizeLabel2.rotation.z = 0;
                    labelsSideRight.add(sizeLabel2);
                }

                //if(stepEn / 3 >= 7 || (length === 60) || (length === 61) || (length === 62) || (length === 63)){
				if(stepEn / 3 >= 7 || (length >= 60 && length <= 63) || (length >= 21 && length <=	27.1) || (length > 40 && length <= 44)){
					
                    var t = 1000;
					
                    for(var i = 0 ; i <= length - (length % stepEn); i += stepEn / 3){
						                    	
                        if(parseInt(i) % parseInt(stepEn) !== 0 && parseInt(i) % parseInt(stepEn) !== parseInt(stepEn - 1) && parseInt(i) % parseInt(stepEn) !== 1 && parseInt(i) % parseInt(stepEn) !== 2 && parseInt(i) % parseInt(stepEn) !== 3 && parseInt(i) % parseInt(stepEn) !== 4){
                            
							if(t % 2 == 0){
								
                                var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 1, 0);
                                var sizeLabel3 = sizeLabel.clone();
                                sizeLabel3.position.set(0 + i, (width) + 2.3, 0);
                                sizeLabel3.rotation.z = 0;
                                labelsSideRight.add(sizeLabel3);
                            }
							
                            if(t % 2 != 0){

                                var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 2, 0);
                                var sizeLabel3 = sizeLabel.clone();
                                sizeLabel3.position.set(0 + i, (width) + 2.3, 0);
                                sizeLabel3.rotation.z = 0;
                                labelsSideRight.add(sizeLabel3);
                            }
							
                            t = t - 1;
                        }
                    }
                }

                else{

                    for(var i = 0 ; i <= length - (length % stepEn); i += stepEn / 2){
						                    	
                        if(parseInt(i) % parseInt(stepEn) !== 0 && parseInt(i) % parseInt(stepEn) !== parseInt(stepEn - 1) && parseInt(i) % parseInt(stepEn) !== 1 && parseInt(i) % parseInt(stepEn) !== 2 && parseInt(i) % parseInt(stepEn) !== 3 && parseInt(i) % parseInt(stepEn) !== 4){
                            
                                var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 1 , 0);
                                var sizeLabel3 = sizeLabel.clone();
                                sizeLabel3.position.set(0 + i, width, 0);
                                sizeLabel3.rotation.z = 0;
                                labelsSideRight.add(sizeLabel3);
                        }
                    }
                }
				
				//labessideleft
				for(var i = 0 ; i <= length - (length % stepEn); i += stepEn){

                    var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn), 32);
                    var sizeLabel2 = sizeLabel.clone();
                    sizeLabel2.position.set(0 + i, -3.3, 0);
                    sizeLabel2.rotation.z = 0;
                    labelsSideLeft.add(sizeLabel2);
                }

                //if((stepEn / 3 >= 7) || (length === 60) || (length === 61) || (length === 62) || (length === 63)){
				if(stepEn / 3 >= 7 || (length >= 60 && length <= 63) || (length >= 21 && length <= 27.1) || (length > 40 && length <= 44)){
				
                    var t = 1000;
					
                    for(var i = 0 ; i <= length - (length % stepEn); i += stepEn / 3){
						
                        if(parseInt(i) % parseInt(stepEn) !== 0 && parseInt(i) % parseInt(stepEn) !== parseInt(stepEn - 1) && parseInt(i) % parseInt(stepEn) !== 1 && parseInt(i) % parseInt(stepEn) !== 2 && parseInt(i) % parseInt(stepEn) !== 3 && parseInt(i) % parseInt(stepEn) !== 4) {
                            
							if (t % 2 == 0){
								
                                var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 1, 0);
                                var sizeLabel3 = sizeLabel.clone();
                                sizeLabel3.position.set(0 + i, - 3.3, 0);
                                sizeLabel3.rotation.z = 0;
                                labelsSideLeft.add(sizeLabel3);
                            }
							
                            if(t % 2 != 0){

                                var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 2, 0);
                                var sizeLabel3 = sizeLabel.clone();
                                sizeLabel3.position.set(0 + i, -3.3, 0);
                                sizeLabel3.rotation.z = 0;
                                labelsSideLeft.add(sizeLabel3);
                            }
							
                            t = t - 1;
                        }
                    }
                }

                else{

                    for(var i = 0; i <= length - (length % stepEn); i += stepEn / 2){
						
                        //console.log(parseInt(stepEn) + "-stepEn & i - " + parseInt(i) +" sonuc " + parseInt(i)%parseInt(stepEn));
                        if(parseInt(i)%parseInt(stepEn) !== 0 && parseInt(i) % parseInt(stepEn) !== parseInt(stepEn - 1) && parseInt(i)%parseInt(stepEn) !== 1 && parseInt(i)%parseInt(stepEn) !== 2 && parseInt(i) % parseInt(stepEn) !== 3 && parseInt(i) % parseInt(stepEn) !== 4){
                            
                        	var sizeLabel = this.drawTextOnPlane("" + String.fromCharCode(65 + i / stepEn) + 1 , 0);
                        	var sizeLabel3 = sizeLabel.clone();
                        	sizeLabel3.position.set(0 + i, 0, 0);
                        	sizeLabel3.rotation.z = 0 ;
                        	labelsSideRight.add(sizeLabel3);
                        }
                    }
                }
            }

            this.labels.add(labelsFront);
            this.labels.add(labelsBack);
      
            this.labels.add(labelsSideRight);
            this.labels.add(labelsSideLeft);
      
            var textVisible = this.text;
            this.labels.traverse(function(child){
				
                child.visible = textVisible;
            });
      
            this.mainGrid.add(this.labels);
        }

        drawTextOnPlane(text, size){

            var canvas, context, material, plane, texture;

            if(size == null){
				
                size = 256;
            }
    
            canvas = document.createElement('canvas');
            var size = 128;
            canvas.width = size;
            canvas.height = size;
            context = canvas.getContext('2d');
            context.font = "15px sans-serif";
            context.textAlign = 'center';
            context.fillStyle = this.textColor;
            context.fillText(text, canvas.width / 2, canvas.height / 2);
            context.strokeStyle = this.textColor;
            context.strokeText(text, canvas.width / 2, canvas.height / 2);
    
            texture = new THREE.Texture(canvas);
            texture.needsUpdate = true;
            texture.generateMipmaps = true;
            texture.magFilter = THREE.LinearFilter;
            texture.minFilter = THREE.LinearFilter;
    
            material = new THREE.MeshBasicMaterial({

                map: texture,
                transparent: true,
                color: 0xffddff,
                alphaTest: 0.3
            });

            plane = new THREE.Mesh(new THREE.PlaneBufferGeometry(size / 10, size / 10), material);
            //plane.doubleSided = false
            plane.overdraw = true
            return plane;
        }
    }