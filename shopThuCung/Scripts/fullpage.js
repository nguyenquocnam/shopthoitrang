function menu_scroll(){
	let menu = document.getElementsByClassName("menu");
	window.addEventListener('scroll',function(){
		if(document.body.scrollTop>142||document.documentElement.scrollTop>142){
			menu[0].classList.add("event_menu");
		}
		else if(document.body.scrollTop<142||document.documentElement.scrollTop<142){
			menu[0].classList.remove("event_menu");
		}
	});
}
menu_scroll();
function mn_mb(){
	var li = document.querySelectorAll("#mn-mb button");
	var btx = document.querySelectorAll(".menu-mobie>button");
	var div = document.querySelectorAll(".list-mb");
	var icon_mb = document.getElementById("icon-mn-mb");
	var mn_mb =	document.getElementsByClassName("menu-mobie");
	var ctn = document.getElementsByClassName("container");
	btx[0].addEventListener('click', function(){
		ctn[0].classList.remove("an");
		mn_mb[0].classList.remove("hien");
	});
	icon_mb.addEventListener('click',function(){
		ctn[0].classList.add("an");
		mn_mb[0].classList.add("hien");

	} );
	div.forEach(function(item,index){
		li[index].style.transform = 'rotate(0deg)';
		div[index].style.display = 'none';
	});
	// console.log(div);
	li.forEach(function(item,index){
		li[index].addEventListener("click",function(){
			if(div[index].style.display=="none"){
				quaygoc(index,180,0);
				div[index].style.display = "block";
			}else{
				quaygoc(index,0,180);
				div[index].style.display = "none";
			}
		});
	});
	// console.log(li[0].style.transform );

}
function quaygoc(i,cuoi,vitri){
		var li = document.querySelectorAll("#mn-mb button");
		var goc=vitri;
		
		if(goc == cuoi)
			return;
		if(cuoi>vitri){
			var  bien = Math.ceil((cuoi-vitri)/10);
			goc = goc +bien;
		}
		if(cuoi<vitri){
			var bien = Math.ceil((vitri-cuoi)/10);
			goc = goc-bien;
		}
		li[i].style.transform = 'rotate('+goc+'deg)';
		var loop = 'quaygoc('+i+','+cuoi+','+goc+')';
		setTimeout(loop, 10);
	}
// quaygoc(0);
mn_mb();
