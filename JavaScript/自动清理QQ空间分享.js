/*最近有朋友遇到了QQ空间被恶意举报需要全删了才能申诉的问题，但是几千条手动删岂不是吐血？
 *知乎上有删说说的代码但是分享页面怎么清却没人说，自己照着删说说的代码改了一份清理分享页的。*/
function del()
{
	var childIframeArr = document.getElementsByTagName('iframe');
	var newDocument = childIframeArr[0].contentWindow.document;
	var btn = newDocument.getElementsByClassName('c_tx mgrs right btn_delete')[0];
	var list = newDocument.getElementsByClassName('mod_pagenav_main')[0].querySelectorAll('a.c_tx');
	var btn_next = list[list.length-1];
	if( btn != null )
	{
		btn.click();
	}
	else if( btn_next != null )
	{
		
		btn_next.click();
	}
} 
setInterval( del,2000 );