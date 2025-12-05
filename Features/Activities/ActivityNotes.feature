@DataSource:../../DataSource/UserInformation.csv
Feature: Activity Notes Features

  @notes
  Scenario: Crear una nota regular
    Given el usuario abre la app Million
    When ingresa el nombre de usuario "<user>"
    And selecciona el boton continue
    When ingresa el OTP "<OtpCode>"
    Then se debe cargar el listado de leads con el icono de usuario visible
    When Selecciona un lead de la lista
    And selecciona el icono add para agregar una actividad
    When selecciona la opcion 'NOTE'
    And ingresa el texto de la nota 'Nota Test automation'
    And selecciona el boton Save Notes
    Then se debe crear una actividad tipo nota con el texto agregado previamente, la fecha actual y el nombre del agente 'by Agente Calidad stage'
    And the user goes back to the lead list
    When selecciona el icono de usuario
    And selecciona la opcion Sing out
    Then el usuario debe ser redirigido a la pantalla de login


