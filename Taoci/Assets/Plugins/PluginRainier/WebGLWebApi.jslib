/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：封装JavaScript调用接口，用于UnityWebGL打包后调用浏览器程序
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

mergeInto(LibraryManager.library, {

    /**
     * 函数功能：打印信息<br>
     * 参数输入：msg 需要打印的消息<br>
     * 异常信息：无<br>
     */
	_PrintInfo: function (msg) {
		console.log("info:" + Pointer_stringify(msg));
	},

	/**
     * 函数功能：打印错误<br>
     * 参数输入：msg 需要打印的消息<br>
     * 异常信息：无<br>
     */
	_PrintError : function(msg){
		console.log("error:" + Pointer_stringify(msg));
	},

	/**
     * 函数功能：打印警告<br>
     * 参数输入：msg 需要打印的消息<br>
     * 异常信息：无<br>
     */
	_PrintWarring : function(msg){
		console.log("warring:" + Pointer_stringify(msg));
	},

	/**
     * 函数功能：存储strData数据到window对象<br>
     * 参数输入：strData 需要存储的数据<br>
	 * 参数输入：objName 对象名称<br>
     * 异常信息：无<br>
     */
	_SaveStringToWindowObject : function(strData,objName){
		var data = Pointer_stringify(strData);
		var name = Pointer_stringify(objName);
		window[name] = json;
	},

    /**
     * 函数功能：存储data数据到本地文件<br>
     * 参数输入：data 需要存储的数据<br>
	 * 参数输入：objName 对象名称<br>
     * 异常信息：无<br>
     */
	_SaveStringToLocalFile : function(data,fileName){
		
		if(!window.saveAs){
			var saveAs = saveAs
			// IE 10+ (native saveAs)
			|| (typeof navigator !== "undefined" &&
				navigator.msSaveOrOpenBlob && navigator.msSaveOrOpenBlob.bind(navigator))
			// Everyone else
			|| (function(view) {
			"use strict";
			// IE <10 is explicitly unsupported
			if (typeof navigator !== "undefined" &&
				/MSIE [1-9]\./.test(navigator.userAgent)) {
				return;
			}
			var
					doc = view.document
					// only get URL when necessary in case Blob.js hasn't overridden it yet
				, get_URL = function() {
					return view.URL || view.webkitURL || view;
				}
				, save_link = doc.createElementNS("http://www.w3.org/1999/xhtml", "a")
				, can_use_save_link = "download" in save_link
				, click = function(node) {
					var event = doc.createEvent("MouseEvents");
					event.initMouseEvent(
						"click", true, false, view, 0, 0, 0, 0, 0
						, false, false, false, false, 0, null
					);
					node.dispatchEvent(event);
				}
				, webkit_req_fs = view.webkitRequestFileSystem
				, req_fs = view.requestFileSystem || webkit_req_fs || view.mozRequestFileSystem
				, throw_outside = function(ex) {
					(view.setImmediate || view.setTimeout)(function() {
						throw ex;
					}, 0);
				}
				, force_saveable_type = "application/octet-stream"
				, fs_min_size = 0
				, arbitrary_revoke_timeout = 500 // in ms
				, revoke = function(file) {
					var revoker = function() {
						if (typeof file === "string") { // file is an object URL
							get_URL().revokeObjectURL(file);
						} else { // file is a File
							file.remove();
						}
					};
					if (view.chrome) {
						revoker();
					} else {
						setTimeout(revoker, arbitrary_revoke_timeout);
					}
				}
				, dispatch = function(filesaver, event_types, event) {
					event_types = [].concat(event_types);
					var i = event_types.length;
					while (i--) {
						var listener = filesaver["on" + event_types[i]];
						if (typeof listener === "function") {
							try {
								listener.call(filesaver, event || filesaver);
							} catch (ex) {
								throw_outside(ex);
							}
						}
					}
				}
				, FileSaver = function(blob, name) {
					// First try a.download, then web filesystem, then object URLs
					var
							filesaver = this
						, type = blob.type
						, blob_changed = false
						, object_url
						, target_view
						, dispatch_all = function() {
							dispatch(filesaver, "writestart progress write writeend".split(" "));
						}
						// on any filesys errors revert to saving with object URLs
						, fs_error = function() {
							// don't create more object URLs than needed
							if (blob_changed || !object_url) {
								object_url = get_URL().createObjectURL(blob);
							}
							if (target_view) {
								target_view.location.href = object_url;
							} else {
								var new_tab = view.open(object_url, "_blank");
								if (new_tab == undefined && typeof safari !== "undefined") {
									//Apple do not allow window.open, see http://bit.ly/1kZffRI
									view.location.href = object_url
								}
							}
							filesaver.readyState = filesaver.DONE;
							dispatch_all();
							revoke(object_url);
						}
						, abortable = function(func) {
							return function() {
								if (filesaver.readyState !== filesaver.DONE) {
									return func.apply(this, arguments);
								}
							};
						}
						, create_if_not_found = {create: true, exclusive: false}
						, slice
					;
					filesaver.readyState = filesaver.INIT;
					if (!name) {
						name = "download";
					}
					if (can_use_save_link) {
						object_url = get_URL().createObjectURL(blob);
						save_link.href = object_url;
						save_link.download = name;
						click(save_link);
						filesaver.readyState = filesaver.DONE;
						dispatch_all();
						revoke(object_url);
						return;
					}

					if (view.chrome && type && type !== force_saveable_type) {
						slice = blob.slice || blob.webkitSlice;
						blob = slice.call(blob, 0, blob.size, force_saveable_type);
						blob_changed = true;
					}

					if (webkit_req_fs && name !== "download") {
						name += ".download";
					}
					if (type === force_saveable_type || webkit_req_fs) {
						target_view = view;
					}
					if (!req_fs) {
						fs_error();
						return;
					}
					fs_min_size += blob.size;
					req_fs(view.TEMPORARY, fs_min_size, abortable(function(fs) {
						fs.root.getDirectory("saved", create_if_not_found, abortable(function(dir) {
							var save = function() {
								dir.getFile(name, create_if_not_found, abortable(function(file) {
									file.createWriter(abortable(function(writer) {
										writer.onwriteend = function(event) {
											target_view.location.href = file.toURL();
											filesaver.readyState = filesaver.DONE;
											dispatch(filesaver, "writeend", event);
											revoke(file);
										};
										writer.onerror = function() {
											var error = writer.error;
											if (error.code !== error.ABORT_ERR) {
												fs_error();
											}
										};
										"writestart progress write abort".split(" ").forEach(function(event) {
											writer["on" + event] = filesaver["on" + event];
										});
										writer.write(blob);
										filesaver.abort = function() {
											writer.abort();
											filesaver.readyState = filesaver.DONE;
										};
										filesaver.readyState = filesaver.WRITING;
									}), fs_error);
								}), fs_error);
							};
							dir.getFile(name, {create: false}, abortable(function(file) {
								// delete file if it already exists
								file.remove();
								save();
							}), abortable(function(ex) {
								if (ex.code === ex.NOT_FOUND_ERR) {
									save();
								} else {
									fs_error();
								}
							}));
						}), fs_error);
					}), fs_error);
				}
				, FS_proto = FileSaver.prototype
				, saveAs = function(blob, name) {
					return new FileSaver(blob, name);
				}
				;
				FS_proto.abort = function() {
					var filesaver = this;
					filesaver.readyState = filesaver.DONE;
					dispatch(filesaver, "abort");
				};
				FS_proto.readyState = FS_proto.INIT = 0;
				FS_proto.WRITING = 1;
				FS_proto.DONE = 2;

				FS_proto.error =
				FS_proto.onwritestart =
				FS_proto.onprogress =
				FS_proto.onwrite =
				FS_proto.onabort =
				FS_proto.onerror =
				FS_proto.onwriteend =
					null;
				window.saveAs = saveAs;
				return saveAs;
			}(
					typeof self !== "undefined" && self
				|| typeof window !== "undefined" && window
				|| this.content
			));
			if (typeof module !== "undefined" && module !== null) {
				module.exports = saveAs;
			} else if ((typeof define !== "undefined" && define !== null) && (define.amd != null)) {
				define([], function() {
				return saveAs;
				});
			}
		}

		var content = Pointer_stringify(data);
		var file    = Pointer_stringify(fileName);
		var blob    = new Blob([content], {type: "text/plain;charset=utf-8"});
		window.saveAs(blob, file);
	},

	/**
     * 函数功能：读取本地文件内容<br>
     * 返回信息：读取的文件内容<br>
     * 异常信息：无<br>
     */
	_ReadFileFromLocal : function(gameObjectName,onLoadedCallback){
		var goName = Pointer_stringify(gameObjectName);
		var cbName = Pointer_stringify(onLoadedCallback);
		var listenerFunc = {
			handleFiles : function(){
				var selectedFile = document.getElementById("readExpJson").files[0];
		        var name 	= selectedFile.name;
		        var size 	= selectedFile.size;
		        var reader 	= new FileReader();
		        reader.readAsText(selectedFile);
		        reader.onload = function(){
					SendMessage(goName, cbName,this.result);
					var readEle = document.getElementById("readExpJson");
					document.body.removeChild(readEle);
		        };
			}
		};

		var body = document.getElementsByTagName("body");
		var fileInput = document.getElementById("readExpJson");
		if(!fileInput){
			fileInput = document.createElement('input');  
			fileInput.setAttribute('type', 'file'); 
			fileInput.setAttribute('id', 'readExpJson');  
			document.body.insertBefore(fileInput,null); 
			fileInput.addEventListener("change", listenerFunc.handleFiles, true);
		}
		var e = document.createEvent("MouseEvents");
		e.initEvent("click", true, true);
		fileInput.dispatchEvent(e);
	},

});

     