class SnakeTableUpdater {
    #intervalID;
    #_timeout;
    #rootnode;

    constructor(time, rootnodeID) {
        this.#_timeout = time;
        this.#rootnode = rootnodeID;

        console.log(this.#rootnode);
        console.log(this.#intervalID);
        console.log(this.#_timeout);
    }


    #Updater(_this) {
        console.log("Вызвано");
        $('#' + _this.#rootnode).load("API/GetField");

        //$('#${_this.#_rootnode}').html("");
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