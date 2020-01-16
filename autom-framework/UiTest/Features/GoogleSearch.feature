Feature: Google Search Feature
    
@mytag
Scenario Outline: Google Search Scenario
    Given I am Google search page
    When I type <search> keyword
    Then I should see the <result>
    
    Examples:
    | search    | result    |
    | selenium1 | selenium1 |
    | globant2  | globant3  |
   
    
