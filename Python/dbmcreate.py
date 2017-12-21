import dbm

db = dbm.open('websites', 'c')

# Add an item
db['www.python.org'] = 'Python home page'

# Close and save to disk
db.close()
