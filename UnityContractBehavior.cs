// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityContractBehavior
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Unity.Wcf
{
  public sealed class UnityContractBehavior : IContractBehavior
  {
    private readonly IInstanceProvider instanceProvider;

    public UnityContractBehavior(IInstanceProvider instanceProvider)
    {
      if (instanceProvider == null)
        throw new ArgumentNullException("instanceProvider");
      this.instanceProvider = instanceProvider;
    }

    public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }

    public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
    {
      if (dispatchRuntime == null)
        throw new ArgumentNullException("dispatchRuntime");
      dispatchRuntime.InstanceProvider = this.instanceProvider;
      dispatchRuntime.InstanceContextInitializers.Add((IInstanceContextInitializer) new UnityInstanceContextInitializer());
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
    }
  }
}
