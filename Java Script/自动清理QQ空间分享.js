/*���������������QQ�ռ䱻����ٱ���Ҫȫɾ�˲������ߵ����⣬���Ǽ�ǧ���ֶ�ɾ������Ѫ��
 *֪������ɾ˵˵�Ĵ��뵫�Ƿ���ҳ����ô��ȴû��˵���Լ�����ɾ˵˵�Ĵ������һ���������ҳ�ġ�*/
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