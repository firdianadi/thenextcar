using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class car
    {
        private AccubatteryController accubatteryController;
        private DoorController doorController;
        private OnCarEngineStatusChanged callBackCarEngineStatusChanged;

        public car(AccubatteryController accubatteryController,
        DoorController doorController,
        OnCarEngineStatusChanged callBackCarEngineStatusChanged)
        {
            this.accubatteryController = accubatteryController;
            this.doorController = doorController;
            this.callBackCarEngineStatusChanged = callBackCarEngineStatusChanged;
        }
        public void closeTheDoor()
        {
            this.doorController.close();
        }

        public void openTheDoor()
        {
            this.doorController.open();
        }

        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }

        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }

        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        private bool powerIsReady()
        {
            return this.accubatteryController.accubatterryIsOn();
        }

        public void StartEngine()
        {
            if (!doorIsClosed())
            {
                this.callBackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is open");
                return;
            }

            if (!doorIsLocked())
            {
                this.callBackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "dor unlocked");
                return;
            }

            if (!powerIsReady())
            {
                this.callBackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "no power available");
                return;
            }
            
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }

        public void togglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }
    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
}
