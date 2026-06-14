# Exercise 02 - Payment Service

Create:

- `IPaymentGateway`
- `FakePaymentGateway`
- `PaymentService`

`PaymentService` should depend on `IPaymentGateway`, not directly on `FakePaymentGateway`.
