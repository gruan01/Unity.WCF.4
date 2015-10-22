// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityServiceHostFactory
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using Microsoft.Practices.Unity;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Unity.Wcf
{
  public abstract class UnityServiceHostFactory : ServiceHostFactory
  {
    protected abstract void ConfigureContainer(IUnityContainer container);

    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      UnityContainer unityContainer = new UnityContainer();
      this.ConfigureContainer((IUnityContainer) unityContainer);
      return (ServiceHost) new UnityServiceHost((IUnityContainer) unityContainer, serviceType, baseAddresses);
    }
  }
}
