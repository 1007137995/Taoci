
var GetLabInfo={
	
	/**
	 * 函数功能：获取实验用户信息及实验或预约实验唯一标识符
     * 参数输入：data 用户信息+实验id（或学生预约实验id）
	 */
	_GetUserInfo : function() {
		
		window.addEventListener('message',function(e){
			var data = e.data;

			if(window.gameInstance){
			
				console.log(window.gameInstance);
				
				var jsonStr=JSON.stringify(data);
				
				window.gameInstance.SendMessage('LabInterSystem', 'SetLabInfoParams',jsonStr);
				return;
			}
			console.error("不能获取unity-gameInstance对象");
			
		  		 
        },false);
		
		window.parent.postMessage('getUserInfo','*');
	},
	
};
mergeInto(LibraryManager.library,GetLabInfo);





