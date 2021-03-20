function chct(){
	let box = document.querySelectorAll(".hiddenl-box");
	let link = location.href;

	let namel;
	if(link.indexOf('listcho')!=-1)
		namel = 'list-cho';
	else if(link.indexOf('listmeo')!=-1)
		namel = 'list-meo';
	else if(link.indexOf('listphukien')!=-1)
		namel = 'list-pk';
	box.forEach(function(item,index){
		console.log(item.id);
		if(item.id.indexOf(namel) != -1)
			item.classList.remove("hiddenl-box");

	});
	
}
chct();
var pageslht=1;
function page(wd_width,sl){
	let lsell = document.querySelectorAll(".list-sell");
	
	lsell.forEach(function(item,index){

		let lsellC = item.children;
		let pr = item.parentElement;
		if(pr.className.indexOf("hiddenl-box")==-1){
			let dPage = pr.children[2];
			// console.log(pr.children);
			cr_page(sl,lsellC,dPage);
		}
	});
}
function add_hd(l){
	// console.log(l);
	for(let i = 0;i<l.length;i++){
				l[i].classList.add("hiddenl-box");
	}		
}
function cr_page(i,c,page){
	console.log(page.children[0].children.length);
	let slPage = Math.ceil(c.length/i);
	add_hd(c);
	for(let q= 0;q<slPage*i;q++){
				if(q>=((pageslht-1)*i)&&q<(pageslht*i)){
					if(c[q])
						c[q].classList.remove("hiddenl-box");
				}
			}
	
	// console.log(slPage);
	while(page.children[0].children.length>0){
		page.children[0].removeChild(page.children[0].children[0]);
	}
	// console.log(slPage);
	if(slPage>=2){
		let x = 0;
		while(x<slPage){

			let li = document.createElement("li");
			li.innerText=(x+1).toString();

			if((x+1)==pageslht)
				li.classList.add("page-sl");
			page.children[0].appendChild(li);
			x++;
		}
	}
	// console.log(page.children[0].children);
	for(let p = 0;p<page.children[0].children.length;p++){
		page.children[0].children[p].addEventListener("click",function(){
			add_hd(c);
			page.children[0].children[pageslht-1].classList.remove("page-sl");
			pageslht=p+1;
			page.children[0].children[pageslht-1].classList.add("page-sl");
			for(let q= 0;q<slPage*i;q++){
				if(q>=((pageslht-1)*i)&&q<(pageslht*i)){
					if(c[q])
						c[q].classList.remove("hiddenl-box");
				}
			}
			
		});
	}
}
page(2,12);
