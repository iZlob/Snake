class SnakeStatusUpdater {
    #intervalID;
    #_timeout;
    #rootnode;

    constructor(time, rootnodeID) {
        this.#_timeout = time;
        this.#rootnode = rootnodeID;
    }


    #Updater(_this) {
        $('#' + _this.#rootnode).load("API/GetStatus");

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