
// var cl = document.getElementsByClassName('box');
// cl[0].addEventListener("scroll", function(){
// 	console.log(cl[0].scrollLeft);
// });
// console.log(cl);
var vtHT = [0, 0, 0, 0];
var movebn = 0;
function bn_move() {

	var slider = document.getElementById("slider");
	var child = document.getElementsByClassName("bn");
	var btn = document.getElementsByClassName('btn-bn');

	if (!slider.style.position)
		slider.style.position = 'relative';
	if (!slider.style.left)
		slider.style.left = "0%";
	var vt = 0;
	var endmove = -(100 * child.length) + 100;
	var start = setInterval('next(' + endmove + ')', 6000);
	btn[1].addEventListener('click', function () {
		next(endmove);
		clearInterval(start);
		start = setInterval('next(' + endmove + ')', 6000);
	});
	btn[0].addEventListener('click', function () {
		prev(endmove);
		clearInterval(start);
		start = setInterval('next(' + endmove + ')', 6000);
	});
	var li_bn = document.querySelectorAll(".btn-cr ul li");
	li_bn.forEach(function (item, index) {
		li_bn[index].addEventListener("click", function () {
			dot(-(index * 100));
			clearInterval(start);
			start = setInterval('next(' + endmove + ')', 6000);
		});
	});




}
function moveX(elementID, cuoi) {
	var slider = document.getElementById(elementID);
	var str = slider.style.left;
	var vitri = parseInt(str.replace("%", ""));
	if (slider.mv) {
		clearTimeout(slider.mv);
	}
	if (vitri == cuoi)
		return;
	if (cuoi > vitri) {
		var bien = Math.ceil((cuoi - vitri) / 10);
		vitri = vitri + bien;
	}
	if (cuoi < vitri) {
		var bien = Math.ceil((vitri - cuoi) / 10);
		vitri = vitri - bien;
	}
	slider.style.left = vitri + "%";
	var loop = 'moveX("' + elementID + '",' + cuoi + ')';
	slider.mv = setTimeout(loop, 10);
}

function dot(cuoi) {
	moveX('slider', cuoi)
}
function next(endmove) {
	movebn = (movebn <= (endmove)) ? 0 : (movebn - 100);
	moveX('slider', movebn);


}
function prev(endmove) {
	movebn = (movebn >= 0) ? (endmove) : (movebn + 100);
	moveX('slider', movebn);
}
bn_move();

function movelist() {
	var box1 = document.querySelectorAll(".box");
	box1.forEach(function (item, index) {
		do {
			let kt = false;
			for (let i = 0; i < item.classList.length; i++) {
				if (ktclass(item.classList[i]) == true)
					kt = true;
			}
			if (kt === false) {
				item.classList.add('box-select');
			}
		} while (false);

	});

	var btn = document.querySelectorAll('.btn-sp-next');
	var btn1 = document.querySelectorAll('.btn-sp-prev');
	var endmove = new Array();

	btn.forEach(function (item, index) {
		item.addEventListener('click', function () {
			var boxSl = document.querySelectorAll('.box-select');
			if (!boxSl[index].style.transform)
				boxSl[index].style.transform = 'translateX(0%)';
			endmove[index] = -(((parseInt(boxSl[index].children.length / 5) - 1) * 100) + ((boxSl[index].children.length % 5) * 10 * 2));
			console.log(endmove[index]);
			nextsp('box-select', endmove[index], index, 5);


		});
	});
	btn1.forEach(function (item, index) {
		item.addEventListener('click', function () {
			var boxSl = document.querySelectorAll('.box-select');
			if (!boxSl[index].style.transform)
				boxSl[index].style.transform = 'translateX(0%)';
			endmove[index] = -(((parseInt(boxSl[index].children.length / 5) - 1) * 100) + ((boxSl[index].children.length % 5) * 10 * 2));
			console.log(endmove[index]);
			prevsp('box-select', endmove[index], index, 5);


		});
	});
	var clcmn = document.querySelectorAll('.menu-chon-sp');
	var list_sp = document.querySelectorAll('.list-sp');

	function ktCl1(a, b) {
		return (a === b);
	}
	function ktCl(argument) {
		return (argument === "box-select");
	}
	// console.log(btn);
	function kttron(tong, stp) {
		if (tong % stp == 0)
			return 0;
		return (tong % stp);
	}
	function nextsp(element, endmove, bI, loai) {
		if (vtHT[bI] <= endmove) {
			vtHT[bI] = 0;
		} else {
			if ((vtHT[bI] - 100) < endmove)
				vtHT[bI] = endmove;
			else
				vtHT[bI] = vtHT[bI] - 100;
		}
		let e = document.querySelectorAll('.box-select');
		console.log(e[bI]);
		moveXsp('box-select', vtHT[bI], bI);

	}
	function prevsp(element, endmove, bI, loai) {
		if (vtHT[bI] >= 0) {
			vtHT[bI] = endmove;
		} else {
			if ((vtHT[bI] + 100) > 0)
				vtHT[bI] = 0;
			else
				vtHT[bI] = vtHT[bI] + 100;
		}
		let e = document.querySelectorAll('.box-select');
		console.log(e[bI]);
		moveXsp('box-select', vtHT[bI], bI);

	}

	function typeNext(name) {
		return name == 'btn-next';
	}
	function typePrev(name) {
		return name == 'btn-prev';
	}
	function ktclass(element) {
		if (element === 'hidden-box')
			return true;
		return false;
	}
	// console.log(box1);
}

function moveXsp(element, final, bI) {
	let boxS = document.getElementsByClassName(element);
	console.log(boxS[bI].style.transform);
	let vt = parseInt((boxS[bI].style.transform).match(/-*\d/g).join(""));
	if (boxS[bI].lap)
		clearTimeout(boxS[bI].lap);
	if (vt === final)
		return;
	if (vt > final) {
		let bienT = Math.ceil((vt - final) / 10);
		console.log(bienT);
		console.log(vt);
		vt = vt - bienT;
		console.log(">");
	}
	if (vt < final) {
		let bienT = Math.ceil((-vt + final) / 10);
		vt = vt + bienT;
		console.log("<");
	}
	console.log(vt);
	boxS[bI].style.transform = 'translateX(' + vt + '%)';
	let spLoop = 'moveXsp("' + element + '",' + final + ',' + bI + ')';
	console.log(spLoop);
	// moveXsp('box-select',final,bI);
	boxS[bI].lap = setTimeout(spLoop, 10);
}
movelist();


