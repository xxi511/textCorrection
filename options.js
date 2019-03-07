document.addEventListener("DOMContentLoaded", restore_options);
document.getElementById("btn-import").addEventListener("click", importData);
document.getElementById("btn-save").addEventListener("click", clickBtnSave);
var dicArea = document.getElementById("dicArea");

function importData() {
    let selectedFile = document.getElementById("input").files[0];
    if (selectedFile.name != "data.txt") {
        alert("請提供data.txt");
        return;
    }
    var reader = new FileReader();

    reader.onload = function() {
        let words = reader.result;
        dicArea.value = words;
        save_wordDictionary(words);
    };
    reader.readAsText(input.files[0]);
}

function save_wordDictionary(words) {
    if (words) {
        // localStorage.setItem("dic", words);
        chrome.storage.local.set({ dic: words }, function() {
            alert("存檔成功");
        });
    } else {
        alert("存檔失敗，因爲字庫是空的QQ");
    }
}

function clickBtnSave() {
    let words = dicArea.value;
    save_wordDictionary(words);
}

function restore_options() {
    // let val1 = localStorage.getItem("dic");
    chrome.storage.local.get(["dic"], function(result) {
        if (result) {
            dicArea.value = result["dic"];
        }
    });
}
