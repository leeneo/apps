/*
*Author:Leeneo
*Contact:leeneo@xingzhihen.com
*Words:写Javascrtip很爽的地方就在于，看似很复杂的功能其实也就几行代码而已。
*/
//在此初始化要加载的元素集合，index为界面默认显示的条数
var $objs = $('ul li');
var index = 5;
var n = 1;
console.log("条目总数："+$objs.length);

//初始化，首次加载条数为index.
$objs.slice(index).hide();

//加载后续未显示条目
function getMore(index,obj) {
console.log("加载 " + n+" 次");
if (index * n <= $objs.length){
n++;
$objs.slice(index, index * n).fadeIn(500);
} else {
$(obj).html('显示完毕');
//console.log(obj);
}
}

//查看更多点击事件
var $click = $('.am-list-news-ft');
$click.children().click(function () {
getMore(index,this);
});


