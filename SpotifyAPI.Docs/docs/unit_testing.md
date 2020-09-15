---
id: unit_testing
title: Unit Testing
---

The modular structure of the library makes it easy to mock the API when unit testing. Consider the following method:

```csharp
public static async Task<bool> IsAdmin(IUserProfileClient userProfileClient)
{
  // get logged in user
  var user = await userProfileClient.Current();

  // only my user id is an admin
  return user.Id == "1122095781";
}
```

Using `Moq`, this can be tested without doing any network requests:

```csharp
[Test]
public async Task IsAdmin_SuccessTest()
{
  var userProfileClient = new Mock<IUserProfileClient>();
  userProfileClient.Setup(u => u.Current()).Returns(
    Task.FromResult(new PrivateUser
    {
      Id = "1122095781"
    })
  );

  Assert.AreEqual(true, await IsAdmin(userProfileClient.Object));
}
```
