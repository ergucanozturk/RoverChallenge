using System;
using System.Collections.Generic;

namespace RoverChallenge {
    public class Instructions {
        public Instructions (Rover rover, int[] mapSize) {
            this._rover = rover;
            this._mapSize = mapSize;
        }

        public Rover _rover { get; set; }
        public int[] _mapSize { get; set; }
        public string StartInstructions () {

            foreach (var instruction in _rover.Instructions) {
                switch (instruction) {
                    case "L":
                        TurnL ();
                        break;
                    case "R":
                        TurnR ();
                        break;
                    case "M":
                        Move ();
                        break;
                    default:
                        break;
                }
            }
            if (this._rover.xCoordinate < 0 || this._rover.xCoordinate > this._mapSize[0] || this._rover.yCoordinate < 0 || this._rover.xCoordinate > this._mapSize[1]) {
                throw new Exception (message: "Coordinate is out of map boundaries");
            }

            return this._rover.xCoordinate.ToString () + this._rover.yCoordinate.ToString () + this._rover.Direction;

        }
        public void TurnL () {
            switch (this._rover.Direction) {
                case "N":
                    this._rover.Direction = "E";
                    break;
                case "E":
                    this._rover.Direction = "S";
                    break;
                case "S":
                    this._rover.Direction = "W";
                    break;
                case "W":
                    this._rover.Direction = "N";
                    break;
            }
        }
        public void TurnR () {
            switch (this._rover.Direction) {
                case "N":
                    this._rover.Direction = "E";
                    break;
                case "E":
                    this._rover.Direction = "S";
                    break;
                case "S":
                    this._rover.Direction = "W";
                    break;
                case "W":
                    this._rover.Direction = "N";
                    break;
            }
        }
        public void Move () {
            switch (this._rover.Direction) {
                case "N":
                    this._rover.yCoordinate += 1;
                    break;
                case "E":
                    this._rover.xCoordinate += 1;
                    break;
                case "S":
                    this._rover.yCoordinate -= 1;
                    break;
                case "W":
                    this._rover.xCoordinate -= 1;
                    break;
            }
        }
    }
}