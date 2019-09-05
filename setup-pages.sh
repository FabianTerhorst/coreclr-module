git checkout --orphan gh-pages
git reset .
rm -r *
rm .gitignore
echo 'The documentation will be here.' > index.html
git add index.html
git commit -m 'Initialize the gh-pages orphan branch'
git push -u origin gh-pages