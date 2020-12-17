# Unity3d Пример взаимодействия с HTML

после экспорта проекта требуется отредактировать index.html файл, добавить в него кнопки и указатель на юнити двиг

```js
var myGameInstance = null;//<< добавляем это
      var script = document.createElement("script");
      script.src = loaderUrl;
      script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
myGameInstance = unityInstance;//<< добавляем это
          loadingBar.style.display = "none";
          fullscreenButton.onclick = () => {
            unityInstance.SetFullscreen(1);
          };
        }).catch((message) => {
          alert(message);
        });
```

```html
	<input id="elem1" type="button" value="Left">
	<script>
	  elem1.onclick = function() {
		var pos = {x:-1,y:0,z:0};
		myGameInstance.SendMessage('Player', 'AddTargetPos',JSON.stringify(pos));
	  };
	</script>
	<input id="elem2" type="button" value="Up">
	<script>
	  elem2.onclick = function() {
		var pos = {x:0,y:0,z:1};
		myGameInstance.SendMessage("Player","AddTargetPos", JSON.stringify(pos));
	  };
	</script>
	<input id="elem3" type="button" value="Right">
	<script>
	  elem3.onclick = function() {
		var pos = {x:1,y:0,z:0};
		myGameInstance.SendMessage("Player","AddTargetPos", JSON.stringify(pos));
	  };
	</script>
	<input id="elem4" type="button" value="Down">
	<script>
	  elem4.onclick = function() {
		var pos = {x:0,y:0,z:-1};
		myGameInstance.SendMessage("Player","AddTargetPos", JSON.stringify(pos));
	  };
	</script>
	<input id="elem_0" value="Text">
```

все функции/методы связанные с **JS/HTML** можно прописать в файле **Assets/jsLibrary.jslib**
для того чтоб можно было это вызывать из Unity3d прописываем функции/методы в файле **Assets/callToJs.cs**
после этого мы можем обращаться к классу **callToJS** и вызывать их внутри юнити.