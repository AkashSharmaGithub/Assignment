using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.Player
{
    public class PlayerActions
    {
        public List<IAmPlayerAction> ActiveActionList { get;private set; }
        public IAmPlayerAction ReloadAction { get;private set; }
        public IAmPlayerAction PickUpAction { get;private set; }
        public IAmPlayerAction IdleAction { get;private set; }
        public IAmPlayerAction AimAction { get;private set; }
        public IAmPlayerAction ShootAction { get;private set; }
        private PlayerStateManager manager;
        private List<IAmPlayerAction> tempActionList; 
        public PlayerActions(PlayerStateManager manager)
        {
            this.manager = manager;
            ReloadAction = new ReloadAction();
            PickUpAction = new PickUpAction();
            IdleAction = new IdleAction();
            ShootAction = new ShootAction();
            ActiveActionList = new List<IAmPlayerAction>();
            ActiveActionList.Add(IdleAction);
        }
        
        public void AddAction(IAmPlayerAction action)
        {
            ActiveActionList.Add(action);
        }
        public void RemoveAction(IAmPlayerAction action)
        {
            ActiveActionList.Remove(action);

        }
        public void Tick()
        {
           
            PerformActions();
        }
        public void PerformActions()
        {
            tempActionList=new List<IAmPlayerAction>(ActiveActionList);
            foreach (IAmPlayerAction action in tempActionList)
            {
                action.PerformAction(manager);

            }

            //update the action
        }

    }
}
