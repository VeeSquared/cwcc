// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/order.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Proto {
  public static partial class RemoteOrder
  {
    static readonly string __ServiceName = "RemoteOrder";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Proto.OrderEmptyRequest> __Marshaller_OrderEmptyRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrderEmptyRequest.Parser));
    static readonly grpc::Marshaller<global::Proto.OrdersReply> __Marshaller_OrdersReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrdersReply.Parser));
    static readonly grpc::Marshaller<global::Proto.OrderSearchRequest> __Marshaller_OrderSearchRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrderSearchRequest.Parser));
    static readonly grpc::Marshaller<global::Proto.OrderReply> __Marshaller_OrderReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrderReply.Parser));
    static readonly grpc::Marshaller<global::Proto.OrderSuccess> __Marshaller_OrderSuccess = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrderSuccess.Parser));
    static readonly grpc::Marshaller<global::Proto.OrderRequest> __Marshaller_OrderRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Proto.OrderRequest.Parser));

    static readonly grpc::Method<global::Proto.OrderEmptyRequest, global::Proto.OrdersReply> __Method_GetAll = new grpc::Method<global::Proto.OrderEmptyRequest, global::Proto.OrdersReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_OrderEmptyRequest,
        __Marshaller_OrdersReply);

    static readonly grpc::Method<global::Proto.OrderSearchRequest, global::Proto.OrderReply> __Method_GetOrderById = new grpc::Method<global::Proto.OrderSearchRequest, global::Proto.OrderReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetOrderById",
        __Marshaller_OrderSearchRequest,
        __Marshaller_OrderReply);

    static readonly grpc::Method<global::Proto.OrderSearchRequest, global::Proto.OrderSuccess> __Method_DeleteOrderById = new grpc::Method<global::Proto.OrderSearchRequest, global::Proto.OrderSuccess>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteOrderById",
        __Marshaller_OrderSearchRequest,
        __Marshaller_OrderSuccess);

    static readonly grpc::Method<global::Proto.OrderRequest, global::Proto.OrderSuccess> __Method_AddItem = new grpc::Method<global::Proto.OrderRequest, global::Proto.OrderSuccess>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddItem",
        __Marshaller_OrderRequest,
        __Marshaller_OrderSuccess);

    static readonly grpc::Method<global::Proto.OrderRequest, global::Proto.OrderSuccess> __Method_UpdateById = new grpc::Method<global::Proto.OrderRequest, global::Proto.OrderSuccess>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateById",
        __Marshaller_OrderRequest,
        __Marshaller_OrderSuccess);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Proto.OrderReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RemoteOrder</summary>
    [grpc::BindServiceMethod(typeof(RemoteOrder), "BindService")]
    public abstract partial class RemoteOrderBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Proto.OrdersReply> GetAll(global::Proto.OrderEmptyRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Proto.OrderReply> GetOrderById(global::Proto.OrderSearchRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Proto.OrderSuccess> DeleteOrderById(global::Proto.OrderSearchRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Proto.OrderSuccess> AddItem(global::Proto.OrderRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Proto.OrderSuccess> UpdateById(global::Proto.OrderRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for RemoteOrder</summary>
    public partial class RemoteOrderClient : grpc::ClientBase<RemoteOrderClient>
    {
      /// <summary>Creates a new client for RemoteOrder</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RemoteOrderClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RemoteOrder that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RemoteOrderClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RemoteOrderClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RemoteOrderClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Proto.OrdersReply GetAll(global::Proto.OrderEmptyRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.OrdersReply GetAll(global::Proto.OrderEmptyRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAll, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrdersReply> GetAllAsync(global::Proto.OrderEmptyRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrdersReply> GetAllAsync(global::Proto.OrderEmptyRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAll, null, options, request);
      }
      public virtual global::Proto.OrderReply GetOrderById(global::Proto.OrderSearchRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrderById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.OrderReply GetOrderById(global::Proto.OrderSearchRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetOrderById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderReply> GetOrderByIdAsync(global::Proto.OrderSearchRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrderByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderReply> GetOrderByIdAsync(global::Proto.OrderSearchRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetOrderById, null, options, request);
      }
      public virtual global::Proto.OrderSuccess DeleteOrderById(global::Proto.OrderSearchRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteOrderById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.OrderSuccess DeleteOrderById(global::Proto.OrderSearchRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteOrderById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> DeleteOrderByIdAsync(global::Proto.OrderSearchRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteOrderByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> DeleteOrderByIdAsync(global::Proto.OrderSearchRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteOrderById, null, options, request);
      }
      public virtual global::Proto.OrderSuccess AddItem(global::Proto.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.OrderSuccess AddItem(global::Proto.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddItem, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> AddItemAsync(global::Proto.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> AddItemAsync(global::Proto.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddItem, null, options, request);
      }
      public virtual global::Proto.OrderSuccess UpdateById(global::Proto.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.OrderSuccess UpdateById(global::Proto.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> UpdateByIdAsync(global::Proto.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.OrderSuccess> UpdateByIdAsync(global::Proto.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateById, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RemoteOrderClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RemoteOrderClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RemoteOrderBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetOrderById, serviceImpl.GetOrderById)
          .AddMethod(__Method_DeleteOrderById, serviceImpl.DeleteOrderById)
          .AddMethod(__Method_AddItem, serviceImpl.AddItem)
          .AddMethod(__Method_UpdateById, serviceImpl.UpdateById).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RemoteOrderBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.OrderEmptyRequest, global::Proto.OrdersReply>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetOrderById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.OrderSearchRequest, global::Proto.OrderReply>(serviceImpl.GetOrderById));
      serviceBinder.AddMethod(__Method_DeleteOrderById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.OrderSearchRequest, global::Proto.OrderSuccess>(serviceImpl.DeleteOrderById));
      serviceBinder.AddMethod(__Method_AddItem, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.OrderRequest, global::Proto.OrderSuccess>(serviceImpl.AddItem));
      serviceBinder.AddMethod(__Method_UpdateById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.OrderRequest, global::Proto.OrderSuccess>(serviceImpl.UpdateById));
    }

  }
}
#endregion
