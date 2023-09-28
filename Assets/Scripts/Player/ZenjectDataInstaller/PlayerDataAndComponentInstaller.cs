using MagicCraft.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MagicCraft.Player
{
    public class PlayerDataAndComponentInstaller : MonoInstaller<PlayerDataAndComponentInstaller>
    {
        public CharacterAttributesSO characterAttributeSo;
  
        public override void InstallBindings()
        {
            
           PlayerData data=new PlayerData(characterAttributeSo);
           Container.BindInstance(data).WhenInjectedInto<PlayerStateManager>();
           Container.Bind<IProvideInput>().To<PlayerInputHandler>().AsSingle();
            Container.Bind<PlayerStateManager>().FromComponentInHierarchy().AsSingle();
            
            
        }
    }
}
