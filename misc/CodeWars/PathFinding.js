function pathFinder(maze){
  let hasExit = false;
  let n = maze.indexOf('\n');
  let m = maze.split('\n').map(r => r.split('').map(c => c == '.'))
          .reduce((a,b) => a.concat(b),[]);
  console.log(maze, '\n');
  console.log(m);
  let exit = n*n - 1;
  let Q = [];
  let π = {0: true};
  Q.push(0);
  while(Q.length > 0) {
    u = Q.pop();
    if (u == exit) {hasExit = true; break; };
    console.log(adj(u, m, n));
    for (let v of adj(u, m, n)) {
      if (!π[v]) {
        Q.push(v);
        π[v] = u;
      }
    }
  }
  printPaths(m, n, π);
  return hasExit;
}

function adj(x, maze, n) {
  let moves = [];
  if (x + 1 % n != 0 && maze[x+1]) moves.push(x+1);
  if (x + n < maze.length && maze[x + n]) moves.push(x+n);
  if (x % n != 0 && maze[x - 1]) moves.push(x-1);
  if (x >= n && maze[x - n]) moves.push(x-n);
  return moves;
}

function W (u, v, maze, n) {
  return Math.abs((n / u) - (n / v)) + Math.abs((u % n) - (v % n)); 
}

function printPaths(maze, n, π) {
  let graph = '';
  for (let i in maze) {
    if (i % n == 0) graph += '\n';
    if (maze[i]) {
      let c = '.';
      if (π[i] + 1 == i) c = '<';
      else
      if (π[i] - 1 == i)  c = '>';
      else
      if (π[i] - n == i) c = 'v';
      else
      if (π[i] + n == i) c = '^';
      graph += c;
    } else graph += 'W';
  }
      console.log('\n', graph, '\n');
}

//////////////////////////

function pathFinder(maze){
  let n = maze.indexOf('\n');
  let m = maze.split('\n').map(r => r.split('').map(c => c == '.'))
          .reduce((a,b) => a.concat(b), []);
  let exit = n*n - 1;
  let Q = [];
  let Δ = {0: 0};
  Q.push(0);
  while(Q.length > 0) {
    let u = Q.pop();
    for (let v of adj(u, m, n)) {
      let w = Δ[u] + 1;
      if ((!Δ[v]) || w < Δ[v]) {
        Q.push(v);
        Δ[v] = w;
      }
    }
  }
  return exit == 0 ? 0 : (Δ[exit] || false);
}
