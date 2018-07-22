Feature: EmbarquerUnPassager

Background: 
Given Un train est limite a 50 places

Scenario: Le passager embarque dans le train vide
Given Le train 123 est en gare
Given Le passager 456 est a quai
When Le passager monte dans le train
Then Le nombre de passager est de 1
Then Le passager est dans le train

Scenario: Le passager embarque dans le train
Given Le train 123 est en gare
Given Le train contient 47 passagers
Given Le passager 456 est a quai
When Le passager monte dans le train
Then Le nombre de passager est de 48
Then Le passager est dans le train

Scenario: Le passager reste a quai
Given Le train 123 est en gare
Given Le train contient 50 passagers
Given Le passager 456 est a quai
When Le passager monte dans le train
Then Le nombre de passager est de 50
Then Le passager ne peut pas monter