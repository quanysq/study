using EventSample;

// 创建发布者和订阅者实例
EventPublisher publisher = new EventPublisher();
EventSubscriber subscriber = new EventSubscriber();

// 订阅事件
publisher.CustomEvent += subscriber.HandleEvent;

// 触发事件
publisher.TriggerEvent();

// 取消订阅事件
publisher.CustomEvent -= subscriber.HandleEvent;
