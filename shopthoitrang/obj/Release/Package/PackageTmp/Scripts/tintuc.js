var pageslht=1;
function page(wd_width,sl){
	let lsell = document.getElementById("page"); 
	let lsellC = document.getElementsByClassName("news1");
	console.log(lsellC.length);
	cr_page(sl,lsellC,lsell);

}
function add_hd(l){

	for(let i = 0;i<l.length;i++){
			// console.log(l[i]);
				l[i].classList.add("hidden-box");
	}		
	console.log(l);
}
function cr_page(i,c,page){
	console.log(c);
	let slPage = Math.ceil(c.length/i);
	add_hd(c);
	for(let q= 0;q<slPage*i;q++){
				if(q>=((pageslht-1)*i)&&q<(pageslht*i)){
					if(c[q])
						c[q].classList.remove("hidden-box");
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
						c[q].classList.remove("hidden-box");
				}
			}
			
		});
	}
}
page(2,7);