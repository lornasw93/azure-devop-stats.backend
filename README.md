# DevOp Stats Backend

***Currently a work in progress, with my initial thoughts below on what to include in the project and why it would be beneficial. Also a bit about what the project is about.***

## Why?

Everyday (more or less), I hear the same things being asked/said:
  - Who broke the build?
  - When was the last release?
  - Balancing out work items
  - Generally people not being aware of what other people were up to project wise
  - Can someone please send over the UAT URL?
  - Which server is WebsiteA hosted on?
  
See more examples below. I started up this project for my own learning, but also feel would be beneficial for a dev team and the project manager. The purpose of this project is to get an overview of useful everyday stats from DevOps. The expected outcome is to have 3 projects working together (frontend, backend and identity server) using .NET Core and Angular 8.

## Benefits
- Efficiency
- Less clicks
- Save time by asking same things
- (Chart) trends

## Common queries/statements
- Project description  
- Bob has 6 bugs assigned to him and bill has 1 - to rethink about sharing
- Bob is working on Project A whilst bill is working on Project B
### Builds
  - Count
  - When was the last time Project A was built?
  - Can quickly see the latest build is broken/who broke the last build (i.e. fewer clicks to find out)
  - Overall stats for build success/failures - line graph and pie chart
### Releases
  - Count
  - Last time was deployed?
  - Can quickly see the latest deployment is broken/who broke the last release (i.e. fewer clicks to find out)
  - Overall stats for release success/failures - line graph and pie chart
  - List of URLs with environment names
### Sprint
  - How many sprints have there been?
  - What is the current sprint?
  - When is the next sprint meeting? 
  - How many work items left to do in current sprint?
  - Who’s completed the most work items in the current sprint?
### Repos
  - List of repos per project including count
### Commits
  - List of commits by project
### Backlog
  - How many work items in backlog?
### Wiki
  - Link
### Pull requests
  - List all active pull requests across all projects
  - List all active pull requests for Project A
### Test plan
  - List of test plans
  - Count of test plans
