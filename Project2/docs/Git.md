# Git Cheat Sheet

New to Git? The following commands might be helpful!

`git clone https://github.com/danielbarnes175/Project2.git` - Clone (download) the repository. You should only need to do this once.  

## Development Workflow

1. Create a new Branch - `git checkout -b "my-feature"`
2. Make your changes
3. Add the files to be committed - `git add .`
4. Commit the files - `git commit -m "Put a description of your changes here!"`
5. Push the changes `git push --set-upstream my-feature` (Note: You only need to do `--set-upstream my-feature` the first time you push from a branch.

Congratulations! You've successfully pushed your changes. Now go to GitHub and open a Pull Request (PR) to merge your changes into the main branch.

### Changes on main?

`git checkout main` - Switch to main
`git pull` - Merge the changes on GitHub to your local branch. Note: This will pull from the current branch you're on

Want to pull from a different branch?

`git pull origin main --rebase` - Pull the changes from main to your branch. Note: This can bring about merge conflicts.