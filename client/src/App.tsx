import { useEffect, useState } from "react"

function App() {
  const title = 'Welcome to Reactivities!'
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/activities')
    .then(response => response.json())
    .then(data => setActivities(data))

    return () => {}
  }, [])

  return (
    <div>
      <h3 className="app" style={{color: "purple"}}>{title}</h3>
      <ul>
        {activities.map((activity) => (
          <li key={activity.id}>{activity.title}</li>
        ))}        
      </ul>
    </div>
  )
}

export default App
