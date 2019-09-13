from math import sqrt, floor

def printSudoku(puzzle):
	n = len(puzzle)
	for x in range(n):
		print(puzzle[x])

def sudoku_solver(puzzle):

	def box(x, y):
		bsize = floor(sqrt(n))
		return (x // bsize) + ((y // bsize) * bsize) 

	def options(sq):
		b = 1
		while b <= n:
			if not sq & 1:
				yield b
			b = b + 1
			sq = sq >> 1

	def moves(x, y):
		sq = R[x] | C[y] | B[box(x, y)]
		b = 1
		while b <= n:
			if not sq & 1:
				yield b
			b = b + 1
			sq = sq >> 1

	def count(i):
		c = 0
		while i:
			i = i & (i-1)
			c = c + 1
		return n - c

	# Initialize tables
	n = len(puzzle)
	R = [0] * n
	C = [0] * n
	B = [0] * n
	O = [[0] * n for _ in range(n)]

	for x in range(n):
		for y in range(n):
			if puzzle[x][y] > 0:
				bit = 1 << puzzle[x][y] - 1
				R[x] |= bit
				C[y] |= bit
				B[box(x,y)] |= bit

	# options per square
	for x in range(n):
		for y in range(n):
			O[x][y] = list(moves(x, y))

	# Solve
	solved = False
	done = False

	# Trivial squares
	while not done:
		solved = True
		done = True
		for x in range(n):
			for y in range(n):
				if puzzle[x][y] == 0:
					solved = False
					m = list(moves(x, y))
					if len(m) == 1:
						done = False
						puzzle[x][y] = m[0]
						bit = 1 << puzzle[x][y] - 1
						R[x] |= bit
						C[y] |= bit
						B[box(x,y)] |= bit
						O[x][y] = list(moves(x, y))

	for x in range(n):
		for y in range(n):
			if puzzle[x][y] == 0:
				print('('+str(x)+', '+str(y)+')',O[x][y])

	# Check if solved
	'''
	for x in range(n):
		for y in range(n):
			d = puzzle[x][y]
			if d == 0:
				solved = False
	'''
	'''
	if not solved:
		# Brute force with backtracking
		print('BRUTE FORCE!')
		for x in range(n):
			for y in range(n):
				if puzzle[x][y] == 0:
					for m in list(moves(x, y)):
						tmp = [list(row) for row in puzzle]
						tmp[x][y] = m
						result = sudoku_solver(tmp)
						if result['solved']:
							return result
	'''
	return { 'solved': solved, 'puzzle': puzzle }


# Get sample puzzles from here:
service = 'http://www.cs.utep.edu/cheon/ws/sudoku/new'

import requests

SIZE = 9

params = {'size': SIZE, 'difficulty': 3}

data = requests.get(url = service, params = params).json()

if data['response'] == True: 
	puzzle = [[0] * int(data['size'])for  _ in range(int(data['size']))]
	for sq in data['squares']:
		puzzle[sq['x']][sq['y']] = sq['value']
	printSudoku(puzzle)
	print('\n\n')
	result = sudoku_solver(puzzle)
	if result['solved']:
		print('Solved')
	else:
		print('Not solved!')
	printSudoku(puzzle)
else:
	print('There has been an error downloading the data')



# ejemplos de kata (codewars):
puzzle = [[0, 0, 6, 1, 0, 0, 0, 0, 8], 
          [0, 8, 0, 0, 9, 0, 0, 3, 0], 
          [2, 0, 0, 0, 0, 5, 4, 0, 0], 
          [4, 0, 0, 0, 0, 1, 8, 0, 0], 
          [0, 3, 0, 0, 7, 0, 0, 4, 0], 
          [0, 0, 7, 9, 0, 0, 0, 0, 3], 
          [0, 0, 8, 4, 0, 0, 0, 0, 6], 
          [0, 2, 0, 0, 5, 0, 0, 8, 0], 
          [1, 0, 0, 0, 0, 2, 5, 0, 0]]

solution = [[3, 4, 6, 1, 2, 7, 9, 5, 8], 
            [7, 8, 5, 6, 9, 4, 1, 3, 2], 
            [2, 1, 9, 3, 8, 5, 4, 6, 7], 
            [4, 6, 2, 5, 3, 1, 8, 7, 9], 
            [9, 3, 1, 2, 7, 8, 6, 4, 5], 
            [8, 5, 7, 9, 4, 6, 2, 1, 3], 
            [5, 9, 8, 4, 1, 3, 7, 2, 6],
            [6, 2, 4, 7, 5, 9, 3, 8, 1],
            [1, 7, 3, 8, 6, 2, 5, 9, 4]]

print('\n\n\nkata:\n\n')
printSudoku(puzzle)
result = sudoku_solver(puzzle)
if result['solved']:
	print('Solved')
else:
	print('Not solved!')
printSudoku(puzzle)
