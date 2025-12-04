Feature: Login Features

  @DataSource:../../DataSource/UserInformation.csv
  Scenario: Realizar login y sign out exitoso en la app con usuario agente
    Given el usuario abre la app Million
    When ingresa el nombre de usuario "<user>"
    And selecciona el boton continue
    When ingresa el OTP "<OtpCode>"
    Then se debe cargar el listado de leads con el icono de usuario visible
    When selecciona el icono de usuario
    And selecciona la opcion Sing out
    Then el usuario debe ser redirigido a la pantalla de login

  @userstatus
  @DataSource:../../DataSource/UserInformation.csv
  Scenario: Cambiar usuario a available
    Given el usuario abre la app Million
    When ingresa el nombre de usuario "<user>"
    And selecciona el boton continue
    When ingresa el OTP "<OtpCode>"
    Then se debe cargar el listado de leads con el icono de usuario visible
    When selecciona el icono de usuario
    And selecciona la opcion de cambiar status de usuario
    Then Se debe ver el estado "Available" debajo del nombre de usuario
    When selecciona la opcion de cambiar status de usuario
    Then Se debe ver el estado "Do not disturb" debajo del nombre de usuario
    When selecciona la opcion Sing out
    Then el usuario debe ser redirigido a la pantalla de login




