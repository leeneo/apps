/*
* Author:Neo 
* Contact:leeneo@xingzhihen.com
* Site:xingzhihen.com
*/

/**
 *��ȡ����cookie����
 *tips�����ڱ�����ʹ��('cookie name'+'=')�ָ�cookie�ַ��������в�������cookie value ���С�����Ӧ�ó���
 * @param {string} ckName:cookie name;��Ҫ��ȡ��cookie Name.
 * @returns {string} cok:cookie value;�����ص�cookie value.
 */
var getCookie=function (ckName) {
	var cookies = document.cookie;
	var arrcoks = cookies.split(";");
	//array.forEach(function(currentValue, index, arr), thisValue)��currentValue ��ǰԪ�أ����裻
	var cok = "";
	arrcoks.forEach(function (item) {
		var arr = item.split(ckName + "=");
		if (arr.length === 2) {
			cok = arr[1];
		}
	});
	console.log(cok);
	return cok;
}

