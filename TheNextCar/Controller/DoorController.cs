using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callBackOnDoorChanged;

        public DoorController(OnDoorChanged callBackOnDoorChanged)
        {
            this.door = new Door();
            this.callBackOnDoorChanged = callBackOnDoorChanged;
        }

        public void close()
        {
            this.door.close();
            this.callBackOnDoorChanged.doorStatusChanged("CLOSED", "door is closed");
        }

        public void open()
        {
            this.door.open();
            this.callBackOnDoorChanged.doorStatusChanged("OPENED", "door is opened");
        }

        public void activateLock()
        {
            if (this.door.isClosed())
            {
                this.door.activateLock();
                callBackOnDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            }
            else
            {
                unlock();
            }
        }

        public void unlock()
        {
            this.door.unlock();
            callBackOnDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }

        public bool isClose()
        {
            return this.door.isClosed();
        }

        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void doorSecurityChanged(string value, string message);
        void doorStatusChanged(string value, string message);
    }
}
