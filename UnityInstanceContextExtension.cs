// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityInstanceContextExtension
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using Microsoft.Practices.Unity;
using System;
using System.ServiceModel;

namespace Unity.Wcf
{
  public sealed class UnityInstanceContextExtension : IExtension<InstanceContext>
  {
    private IUnityContainer childContainer;

    public void Attach(InstanceContext owner)
    {
    }

    public void Detach(InstanceContext owner)
    {
    }

    public void DisposeOfChildContainer()
    {
      if (this.childContainer == null)
        return;
      this.childContainer.Dispose();
    }

    public IUnityContainer GetChildContainer(IUnityContainer container)
    {
      if (container == null)
        throw new ArgumentNullException("container");
      return this.childContainer ?? (this.childContainer = container.CreateChildContainer());
    }
  }
}
