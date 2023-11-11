class SnakeStatusGetter {
    #intervalID;
    #_timeout;
    /** @type {function()} */
    #_snakeDeadCallback;

    /**
     * 
     * @param {number} timeout
     * @param {function()} snakeDeadCallback
     */
 
    constructor(timeout, snakeDeadCallback) {
        this.#_timeout = timeout;
        this.#_snakeDeadCallback = snakeDeadCallback;
    }

    /**
     * @param {SnakeStatusGetter} _this
     */

    #Updater(_this) {
        $.ajax("API/GetStatusDataModel", {})
            .done((Response) => _this.#OnStatusDataModelReceived(Response, _this))
    }

    /**
     * @private
     * @param {SnakeStatusGetter} _this
     */
    #LazySnakeDeadCallbackCall(_this) {
        setTimeout(function () { 
            _this.#_snakeDeadCallback()
        }, _this.#_timeout)
    }

    /**
     * @private
     * @param {{isSnakeAlive:boolean}} responseData
     * @param {SnakeStatusGetter} _this
     */
    #OnStatusDataModelReceived(responseData, _this) {

        console.log(responseData);

        if (responseData.isSnakeAlive === true) {
            return;
        }

        _this.#LazySnakeDeadCallbackCall(_this);
        _this.Stop();
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