
function movelist(){
	var box1 = document.querySelectorAll(".box");
	box1.forEach(function(item,index){
		do{
			let kt  = false;
			for(let i = 0;i<item.classList.length;i++){
				if(ktclass(item.classList[i])==true)
					kt=true;
			}
			if(kt ===false){
				item.classList.add('box-select');
			}
		}while(false);

	});

	var btn = document.querySelectorAll('.btn-sp-next');
	var btn1 = document.querySelectorAll('.btn-sp-prev');
	var endmove = new Array();
	var vtHT =[0,0,0,0];
	btn.forEach(function(item,index){
		item.addEventListener('click',function(){
			var boxSl = document.querySelectorAll('.box-select');
			if(!boxSl[index].style.transform)
				boxSl[index].style.transform = 'translateX(0%)';
			endmove[index] = -(((parseInt(boxSl[index].children.length/5)-1)*100)+((boxSl[index].children.length%5)*10*2));
			console.log(endmove[index]);

			nextsp('box-select',endmove[index],index,5);
			
			
		});
	});
	btn1.forEach(function(item,index){
		item.addEventListener('click',function(){
			var boxSl = document.querySelectorAll('.box-select');
			if(!boxSl[index].style.transform)
				boxSl[index].style.transform = 'translateX(0%)';
			endmove[index] = -(((parseInt(boxSl[index].children.length/5)-1)*100)+((boxSl[index].children.length%5)*10*2));
			console.log(endmove[index]);
			prevsp('box-select',endmove[index],index,5);
			
			
		});
	});
	var clcmn = document.querySelectorAll('.menu-chon-sp');
	var list_sp = document.querySelectorAll('.list-sp');
	clcmn.forEach(function(item,index){
		item.children[0].children;
		for(let i = 0;i<item.children[0].children.length;i++){
			item.children[0].children[i].addEventListener('click',function(){

				for(let j =0;j<list_sp[index+1].children.length;j++){
					console.log(list_sp[index+1].children[j].classList);
					for(let k=0;k<list_sp[index+1].children[j].classList.length;k++){
						console.log(list_sp[index+1].children[j].classList[k]);
						if(ktCl1(list_sp[index+1].children[j].classList[k],'box-select')){

							list_sp[index+1].children[j].classList.add('hidden-box');
							list_sp[index+1].children[j].classList.remove('box-select');
							// break;
						}

					}
					// break;
				}
				list_sp[index+1].children[i].classList.remove('hidden-box');
				// console.log(list_sp[index].children[i].classList);
				list_sp[index+1].children[i].classList.add('box-select');
				list_sp[index+1].children[i].style.transform = 'translateX(0%)';
				vtHT[index]=0;
			});
		}

	});
	function ktCl1(a,b){
		return (a===b);
	}
	function ktCl (argument) {
			return (argument==="box-select");
	}
	// console.log(btn);
	function kttron(tong,stp){
		if(tong%stp==0)
			return 0;
		return (tong%stp);
	}
	function nextsp(element,endmove,bI,loai){
		if(vtHT[bI]<=endmove){
			vtHT[bI]=0;
		}else{
			if((vtHT[bI]-100)<endmove)
				vtHT[bI]=endmove;
			else 
				vtHT[bI]=vtHT[bI]-100;
		}
		let e = document.querySelectorAll('.box-select');

		moveXsp('box-select',vtHT[bI],bI);

	}
		function prevsp(element,endmove,bI,loai){
		if(vtHT[bI]>=0){
			vtHT[bI]=endmove;
		}else{
			if((vtHT[bI]+100)>0)
				vtHT[bI]=0;
			else 
				vtHT[bI]=vtHT[bI]+100;
		}
		let e = document.querySelectorAll('.box-select');

		moveXsp('box-select',vtHT[bI],bI);

	}

	function typeNext(name){
		return name=='btn-next';
	}
	function typePrev(name){
		return name=='btn-prev';
	}
	function ktclass(element){
		if(element==='hidden-box')
			return true;
		return false;
	}
	// console.log(box1);
}

function moveXsp(element,final,bI){

		let boxS = document.getElementsByClassName(element);

		let vt = parseInt((boxS[bI].style.transform).match(/-*\d/g).join(""));
		if(boxS[bI].lap)
			clearTimeout(boxS[bI].lap);
		if(vt === final)
			return;
		if(vt > final){
			let bienT = Math.ceil((vt-final)/10);

			vt = vt -bienT;

		}
		if(vt < final){
			let bienT = Math.ceil((-vt+final)/10);
			vt = vt +bienT;

		}

		boxS[bI].style.transform = 'translateX('+vt+'%)';
		let spLoop = 'moveXsp("'+element+'",'+final+','+bI+')';

		// moveXsp('box-select',final,bI);
		boxS[bI].lap = setTimeout(spLoop,10);
	}
movelist();

function chct(){
	let box = document.querySelectorAll(".hiddenl-box");
	let link = location.href;

	let namel = "ct";
	
	
	slimg(namel);
}
chct();

function slimg(name){
	let lc = "."+name+" .img-list";
	let lcsl = "."+name+" .img-selected img";
	let imgl = document.querySelectorAll(lc);
	let imgsl = document.querySelector(lcsl);
	let id = 0;
	
	imgl.forEach(function(item,index){

		item.addEventListener("click", function(){
			imgsl.src = item.children[0].src;
			imgl[id].classList.add("img-list-nsl");
			item.classList.remove("img-list-nsl");
			id=index;
		});
		console.log(imgsl.src);
		
	});

	
}
function move_img(){
	let imgBox = document.querySelectorAll(".img-choose");
	console.log(window.innerWidth);
	imgBox.forEach(function(item, index){
		if(!imgBox[index].style.transform)
				imgBox[index].style.transform = 'translateX(0%)';
		imgBox[index].endmove=0;
		for(let i = 0;i<item.children.length;i++){
			if(item.children[i].className.indexOf("img-list")!= -1){
				imgBox[index].endmove +=25;
			}
			
		}
		imgBox[index].endmove-=100;
		imgBox[index].endmove*=-1;
		imgBox[index].vtht = 0;

		let pr =item.parentElement;

		for(let i = 0;i<pr.children.length;i++){
			if(pr.children[i].className.indexOf("btn-prev")!= -1){
				pr.children[i].addEventListener("click", function(){
					prevImg('img-choose',imgBox[index].endmove,index);
				});
			}
			if(pr.children[i].className.indexOf("btn-next")!= -1){
				pr.children[i].addEventListener("click", function(){
					nextImg('img-choose',imgBox[index].endmove,index);
				});
			}
		}

	});


	function nextImg(element,endmove,bI){
		if(imgBox[bI].vtht<=endmove){
			imgBox[bI].vtht=0;
		}else{
			if((imgBox[bI].vtht-100)<endmove)
				imgBox[bI].vtht=endmove;
			else 
				imgBox[bI].vtht=imgBox[bI].vtht-100;
		}
		moveXsp("img-choose",imgBox[bI].vtht,bI);

	}
	function prevImg(element,endmove,bI){
		if(imgBox[bI].vtht>=0){
			imgBox[bI].vtht=endmove;
		}else{
			if((imgBox[bI].vtht+100)>0)
				imgBox[bI].vtht=0;
			else 
				imgBox[bI].vtht=imgBox[bI].vtht+100;
		}
		moveXsp("img-choose",imgBox[bI].vtht,bI);

	}
}
move_img();
