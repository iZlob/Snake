class SnakeStatusGetter {
    #intervalID;
    #_timeout;
 
    constructor(time) {
        this.#_timeout = time;
        
    }

    #Updater(_this) {
        $.ajax("API/GetStatusDataModel", {})
            .done(function (responseData) {
                if (responseData.isSnakeAlive === false) {
                    setTimeout(function () { alert("Game Over\nLoooooser!!!") }, _this.#_timeout)
                    _this.Stop();
                }
        })
    }

    Start() {
        this.Stop();

        this.#intervalID = setInterval(this.#Updater, this.#_timeout, this);
    }

    Stop() {
        if (this.#intervalID) {
            clearInterval(this.#intervalID);
        }
    }
}