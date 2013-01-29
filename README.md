ZedLedger
=========
### The Zediest Ledger Around
##### *(makes no sense to me as well)*

This is a personal ledger program that I have been developing and using myself to track all my finances. It has lead to numerous discoveries for myself as a developer that have accelerated my gaining of knowledge. However, I warn yee, this is still my first program and as a result will probably be pretty terrible in execution.

The concept is that everything we buy can be broken down into a few bits of information that can be then used to help our spending habits/tell us where the hell our money has gone to! These figures include:

	* The account the purchase was charged too (cash on hand can be an "account") e.g. Everyday, High Interest, Cheque
	* The type of expense incurred e.g. Car, Clothes, Bills etc 
	* A futher drill down on the expense, e.g. Car -> Fuel, Clothes -> Shoes, Bills -> Electricity
	
Each of these are set up by the user via the "Setup" tab. Possibly as a future addition it would be great to have a "default" set up for new users that can be customised.

It has basic abilities such as drilling down to where your money has been spend with overall percentages and date ranges.

Further break down containing additional information can be found on the "Breakdown" tab per...mostly everything you've set up.

I wish to add several features:

1. The ability to set up budgets
	* These budgets are "Limits" on that is allowed to be spend on an expense type
	* Will notify if going over
	* Will show some sort of useful information once set up

2. The ability to import from excel
	* In case people (like I) previously used an excel document to keep track 
	* Take in a standard format
	
3. Add a web version:
	* Winforms has very limited uses
	
4. Use some sort of database:
	* Currently using an XML file, not ideal.
	
5. So, so much more.

	
## Setting Up Zedledger:
	* Run the executable (or run project?)
	* Select "Create New Ledger"
	* Visit the "Setup" tab
	* Input your accounts
		* e.g. Everyday, High Interest, Cheque (Cash? - I found a "Cash" account hard to keep track of)
	* Create expense types
		* Use the "Type" to set as appropriate, e.g. "Salary" would be "Income", "Clothing" would be "Expense"
	* Create Secondary Expense types
		* Associate them with their parent expense type
	* Check out the options (Settings -> Options)
	* Start filling in purchases!
