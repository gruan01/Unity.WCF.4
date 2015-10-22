// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityInstanceContextInitializer
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Unity.Wcf
{
  public sealed class UnityInstanceContextInitializer : IInstanceContextInitializer
  {
    public void Initialize(InstanceContext instanceContext, Message message)
    {
      if (instanceContext == null)
        throw new ArgumentNullException("instanceContext");
      instanceContext.Extensions.Add((IExtension<InstanceContext>) new UnityInstanceContextExtension());
    }
  }
}
